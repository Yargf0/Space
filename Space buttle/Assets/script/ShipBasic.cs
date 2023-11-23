using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBasic : MonoBehaviour
{
    public Ship ship;
    public bool player=false;
    public void Damage(float damage)
    {
        ship.Hp -= damage;
        if (ship.Hp < 0)
        {
            Destroy();
        }
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }



}
