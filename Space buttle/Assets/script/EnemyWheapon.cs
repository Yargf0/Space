using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWheapon : WheaponBasic
{
    private void Update()
    {
        if (PlayerController.Instance == null)
            return;
        if (Vector3.Distance(transform.position, PlayerController.Instance.transform.position) < wheapon.RadiusOfFire)   
        {
            Rotate(PlayerController.Instance.transform.position);
            Shoot();
        }                                   
    }

}
