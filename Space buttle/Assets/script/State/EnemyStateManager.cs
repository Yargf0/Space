using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.LowLevel;

public class EnemyStateManager : MonoBehaviour
{
    [SerializeField] public Dictionary<string, System.Action> stateDictionary;
    private System.Action currentState;

    public void SetState(string state)
    {
        Debug.Log("New state = " + state);

        if (stateDictionary.ContainsKey(state))
        {
            currentState = stateDictionary[state];
        }
        
    }
    public System.Action GetCurrentState()
    {
        if (currentState != null)
            return currentState;
        return null;
    }
}
