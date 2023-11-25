using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.LowLevel;

public class EnemyStateManager : MonoBehaviour
{
    public static EnemyStateManager Instance { get; private set; }
    public PatrulState patrulState = new();
    private EnemyBaseStat currentState;
    private void Awake()
    {
        Instance = this;
     
    }
    public void SetState(EnemyBaseStat state)
    {
        Debug.Log("New state = " + state);

        currentState = state;
        currentState.EnterState(this);
    }
    public EnemyBaseStat GetCurrentState()
    {
        if (currentState != null)
            return currentState;
        return null;
    }
    private void FixedUpdate()
    {
        currentState.StateUpdate();
    }
}
