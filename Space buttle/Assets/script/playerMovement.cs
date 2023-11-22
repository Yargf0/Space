using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : ShipBasic
{
    private Rigidbody2D rb2D;
    public void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
    }
    public void FixedUpdate()
    {
        if(Input.GetKey("w"))
        {
                
            rb2D.AddForce(gameObject.transform.up * ship.Speed * Time.deltaTime, ForceMode2D.Force);
        }
        if (Input.GetKey("s"))
        {
            rb2D.AddForce(-gameObject.transform.up * ship.Speed * Time.deltaTime, ForceMode2D.Force);
        }
        if (Input.GetKey("a"))  
        {
            rb2D.MoveRotation(rb2D.rotation+ ship.RotationSpeed * Time.fixedDeltaTime);

        }
        if (Input.GetKey("d"))
        {
            rb2D.MoveRotation(rb2D.rotation - ship.RotationSpeed * Time.fixedDeltaTime);
        }
    }
}
