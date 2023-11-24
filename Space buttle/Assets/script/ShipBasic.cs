using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBasic : MonoBehaviour
{
    public Ship ship;
    public bool player=false;
    private float Hp;
    private void Awake()
    {
        Hp =  ship.Hp;
    }
    public void Damage(float damage)
    {
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
