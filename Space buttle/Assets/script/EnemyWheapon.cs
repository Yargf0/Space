using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWheapon : WheaponBasic
{

    private void Update()
    {
        Debug.Log("0");
        Collider2D[] colliderAray = Physics2D.OverlapCircleAll(gameObject.transform.position, wheapon.RadiusOfFire);
        foreach (Collider2D collider2D in colliderAray)
        {
            Debug.Log("1");
            if (collider2D.TryGetComponent<playerMovement>(out playerMovement ship))
            {
                Debug.Log("2");
                if (ship.player==true)
                {
                    Debug.Log("Target acuired");
                    Rotate(collider2D.transform.position);
                    Shoot();
                }
            }
        }
    }

}
