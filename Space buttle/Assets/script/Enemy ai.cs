using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.RuleTile.TilingRuleOutput;
using Vector3 = UnityEngine.Vector3;

public class EnemyAi : MonoBehaviour
{

    [SerializeField] private Dictionary<string, System.Action> stateDictionary = new();
    private string currentState;
    [SerializeField] private Enemy enemy;

    private Rigidbody2D rb2D;

    private Vector3 randomPosition;

    public void Start()
    {
        randomPosition = transform.position;
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        stateDictionary.Add("Patrule", Patrule);
        stateDictionary.Add("Chase", Chase);
        stateDictionary.Add("Fight", RotateAroundPlayer);
    }
    public void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, playerMovement.Instance.GetPostion()) < enemy.RadiusOfDetection)
        {
            if (Vector3.Distance(transform.position, playerMovement.Instance.GetPostion()) <= enemy.AttackRadius-1f)
            {
                SetState("Fight");
            }
            else
            {
                SetState("Chase");
            }                        
        }
        else
        {
            SetState("Patrule");
        }
    }
    public void SetState(string state)
    {
        if (stateDictionary.ContainsKey(state))
        {
            currentState = state;
            stateDictionary[currentState]();
        }
        
    }
    public string GetCurrentState()
    {
        if (currentState != null)
            return currentState;
        return null;
    }

    public void Chase()
    {
        Rotate(playerMovement.Instance.GetPostion());
        rb2D.AddForce(gameObject.transform.up * enemy.Speed * Time.deltaTime, ForceMode2D.Force);
    }

    public void Patrule()
    {
        if (Vector3.Distance(transform.position, randomPosition) > 4f)
        {
            MoveTo(randomPosition);
        }
        else
        {
            randomPosition = RandomPosition();
        }
    }

    public void RotateAroundPlayer()
    {
        MoveTo(GetCoordinateToMoveInCircle(playerMovement.Instance.GetPostion()));
        
    }

    public void MoveTo(Vector3 position)
    {
        Rotate(position);
        rb2D.AddForce(gameObject.transform.up * enemy.Speed * Time.deltaTime, ForceMode2D.Force);             
    }

    public Vector3 GetCoordinateToMoveInCircle(Vector3 vector)
    {
        float x1 = vector.x;
        float x2 = gameObject.transform.position.x;
        float y1 = vector.y;
        float y2 = gameObject.transform.position.y;
        float a = 2 * (enemy.AttackRadius - 2f) * Mathf.Sin(0.5f * 5);
        float x3 = x1 + (enemy.AttackRadius - 2f) * Mathf.Cos(15) + (enemy.AttackRadius - 2f) * Mathf.Sin(15);
        float y3 = y1 + (enemy.AttackRadius - 2f) * Mathf.Cos(15) - (enemy.AttackRadius - 2f) * Mathf.Sin(15);
        return new Vector3(x3, y3, 0);
    }
    public void Rotate(Vector3 position)
    {
        Vector3 diference = position - transform.position;
        float rotateZ = Mathf.Atan2(diference.y, diference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ + -90);
    }


    private Vector3 GetRandomDirection()
    {
        return new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f)).normalized;
    }

    private Vector3 RandomPosition()
    {
        return transform.position + GetRandomDirection() * Random.Range(10f, 170f);
    }



}
