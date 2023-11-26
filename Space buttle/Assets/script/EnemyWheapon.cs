using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWheapon : WheaponBasic
{
    private void Update()
    {

        if(Vector3.Distance(transform.position, playerMovement.Instance.GetPostion()) < wheapon.RadiusOfFire)   
        {
            Rotate(playerMovement.Instance.GetPostion());
            Shoot();
        }
                    
                
    }

}
