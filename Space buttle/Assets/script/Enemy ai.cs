using System.Collections.Generic;
using UnityEngine;
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
        if (PlayerController.Instance == null)
            return;
        if (Vector3.Distance(transform.position, PlayerController.Instance.transform.position) < enemy.RadiusOfDetection)
        {
            if (Vector3.Distance(transform.position, PlayerController.Instance.transform.position) <= enemy.AttackRadius)
            {
                SetState("Fight");
                Debug.Log("Fight");
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
        Rotate(PlayerController.Instance.transform.position);
        rb2D.AddForce(gameObject.transform.up * enemy.Speed * Time.deltaTime, ForceMode2D.Force);
    }

    public void Patrule()
    {
        RotateInCircle();
    }

    public void RotateAroundPlayer()
    {
        RotatePlayerAroundObject();
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

    void RotateInCircle()
    {
        // Вычисляем угол для вращения по окружностиё
        float angle = Time.time * 5f;

        // Вычисляем новые координаты объекта на окружности
        float x = Mathf.Cos(angle) * 5f;
        float y = Mathf.Sin(angle) * 5f;
        
        // Создаем новый вектор позиции
        Vector3 newPosition = new Vector3(x, y, 0f);
        Rotate(newPosition);

        // Применяем AddForce для движения объекта к новой позиции
        Vector2 force = (newPosition - transform.position).normalized * 5;
        rb2D.velocity = force; // Заменим AddForce на прямое задание скорости

        // Необходимо также обнулить угловую скорость, чтобы объект не вращался вокруг своей оси Z
        rb2D.angularVelocity = 0f;
    }
    private void RotatePlayerAroundObject()
    {
        Vector3 directionToTarget = PlayerController.Instance.transform.position - transform.position;


        Vector3 normalizedDirection = directionToTarget.normalized;

        // Вычисляем вектор, перпендикулярный направлению к целевому объекту
        Vector3 perpendicularDirection = Vector3.Cross(normalizedDirection, Vector3.up);
      
        // Применяем AddForce для движения объекта по кругу
        if (perpendicularDirection.z<0)
        {
            perpendicularDirection = -perpendicularDirection;
        }

        rb2D.AddForce(perpendicularDirection * enemy.Speed);

        Rotate(perpendicularDirection);
        // Ограничиваем максимальную скорость, чтобы избежать проблем с физикой
        rb2D.velocity = Vector3.ClampMagnitude(rb2D.velocity, enemy.Speed);
    }
    private void R()
    {
        Vector3 force = transform.right * enemy.Speed * rb2D.mass;

        // Применяем силу к объекту
        rb2D.AddForce(force);

        // Ограничиваем движение объекта по радиусу
        Vector3 center = transform.position;
        Vector3 currentPosition = rb2D.position;
        Vector3 direction = currentPosition - center;
        direction.Normalize();
        Vector3 targetPosition = center + direction * 10;
        rb2D.MovePosition(targetPosition);
    }
}
