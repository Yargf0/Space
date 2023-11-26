using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAiGroup : MonoBehaviour
{
    [SerializeField] public Dictionary<string, System.Action> stateDictionary=new();
    private string currentState= "";
    [SerializeField] private List<EnemyAi> controldAi;
    [SerializeField] private Enemy enemy;
    [SerializeField] private List<Transform> allPos;
    [SerializeField] private GameObject patruleZone;
    private Vector3 patrulPosition;

    public void Awake()
    {
        stateDictionary.Add("Patrul", Patrul);
        stateDictionary.Add("Chase", Chase);
        StartCoroutine("NewPatrulPosition");
        StartCoroutine("CheckForState");
    }



    public void FixedUpdate()
    {
        if (stateDictionary.ContainsKey(currentState))
        {
            stateDictionary[currentState]();
        }         
    }

    public void SetState(string state)
    {
        Debug.Log("New state = " + state);

        if (stateDictionary.ContainsKey(state))
        {        
            currentState = state;
            stateDictionary[state]();
        }
        
    }
    public string GetCurrentState()
    {
        if (currentState != null)
            return currentState;
        return null;
    }

    
    public void Patrul()
    {;
        for (int i = 0; i < controldAi.Count; i++)
        {
            controldAi[i].SetState("Whait");
            controldAi[i].Rotate(patrulPosition);
        }
        gameObject.transform.position = Vector3.MoveTowards(transform.position, patrulPosition, enemy.Speed);
    }
    public void GoBack()
    {
        for (int i = 0; i < controldAi.Count; i++)
        {
            //controldAi[i].
        }
    }

    public void Chase()
    {
        for (int i = 0; i < controldAi.Count; i++)
        {
            controldAi[i].SetState("Chase");
        }
    }

    IEnumerator NewPatrulPosition()
    {
        float width = patruleZone.transform.localScale.x;
        float height = patruleZone.transform.localScale.y;
        float xl = patruleZone.transform.position.x - width / 2;
        float xr = patruleZone.transform.position.x + width / 2;
        float yt = patruleZone.transform.position.y + height / 2;
        float yb = patruleZone.transform.position.y - height / 2;
        while (true)
        {
            
            patrulPosition = new Vector3(Random.Range(xl, xr), Random.Range(yt, yb));

            yield return new WaitForSeconds(7);
        }
    }

    IEnumerator CheckForState()
    {
        while (true)
        {            
            if (Vector3.Distance(transform.position, playerMovement.Instance.GetPostion()) < enemy.RadiusOfDetection)
            {
                SetState("Chase");
            }
            else
            {
                SetState("Patrul");
            }
            yield return new WaitForSeconds(1);
        }

    }

}
