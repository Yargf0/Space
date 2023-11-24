using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWheapon : WheaponBasic
{

    private void Update()
    {
        Collider2D[] colliderAray = Physics2D.OverlapCircleAll(gameObject.transform.position, wheapon.RadiusOfFire);
        foreach (Collider2D collider2D in colliderAray)
        {
            if (collider2D.TryGetComponent<playerMovement>(out playerMovement ship))
            {
                if (ship.player==true)
                {
                    Rotate(collider2D.transform.position);
                    Shoot();
                }
            }
        }
    }

}
