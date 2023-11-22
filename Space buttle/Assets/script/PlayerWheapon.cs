using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerWheapon : WheaponBasic
{
    private void FixedUpdate()
    {
        Rotate(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        if (Input.GetMouseButton(0))
        {
            Shoot();
        }
    }
}
