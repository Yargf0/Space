using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBasic : MonoBehaviour
{
    public Ship ship;
    public bool player=false;
    private float Hp;
    public void Awake()
    {        
        Hp =  ship.Hp;
    }
    public void Damage(float damage)
    {
        Debug.Log(ship.Name);
        Hp -= damage;
        if (Hp < 0)
        {
            Destroy();
        }
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }



}
