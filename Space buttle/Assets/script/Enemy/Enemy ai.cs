using System.Collections.Generic;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class EnemyAi : EnemyBasic
{
    private Dictionary<string, BaseState> stateDictionary = new();

    [SerializeField] private BaseState Patrule;
    [SerializeField] private BaseState Chase;
    [SerializeField] private BaseState Fight;
    [SerializeField] private List<ParticleSystem> engineParticle;

    private string currentState;

    public void Start()
    {       
        stateDictionary.Add("Patrule", Patrule);
        stateDictionary.Add("Chase", Chase);
        stateDictionary.Add("Fight", Fight);
        foreach (BaseState baseState in stateDictionary.Values)
        {
            baseState.Set(enemy, gameObject, engineParticle);
        }
        foreach(ParticleSystem particle in engineParticle)
        {
            particle.Pause();
        }       
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
            stateDictionary[currentState].Do();
        }       
    }
    public string GetCurrentState()
    {
        if (currentState != null)
            return currentState;
        return null;
    }

    /*

    public Vector3 GetCoordinateToMoveInCircle(Vector3 vector)
    {
        float x1 = vector.x;
        float x2 = gameObject.transform.position.x;
        float y1 = vector.y;
        float y2 = gameObject.transform.position.y;

        float a = 2 * (AttackRadius - 2f) * Mathf.Sin(0.5f * 5);
        float x3 = x1 + (AttackRadius - 2f) * Mathf.Cos(15) + (AttackRadius - 2f) * Mathf.Sin(15);
        float y3 = y1 + (AttackRadius - 2f) * Mathf.Cos(15) - (AttackRadius - 2f) * Mathf.Sin(15);

        return new Vector3(x3, y3, 0);
    }


    void RotateInCircle()
    {
        float angle = Time.time * 5f;
        float x = Mathf.Cos(angle) * 5f;
        float y = Mathf.Sin(angle) * 5f;
        
        Vector3 newPosition = new Vector3(x, y, 0f);
        Rotate(newPosition);
        Vector2 force = (newPosition - transform.position).normalized * 5;

        rb2D.velocity = force; 
        rb2D.angularVelocity = 0f;
    }
    */
}
