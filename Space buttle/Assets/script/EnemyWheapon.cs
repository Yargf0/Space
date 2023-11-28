using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWheapon : WheaponBasic
{
    private void Update()
    {

        if(Vector3.Distance(transform.position, PlayerController.Instance.GetPostion()) < wheapon.RadiusOfFire)   
        {
            Rotate(PlayerController.Instance.GetPostion());
            Shoot();
        }
                    
                
    }

}
