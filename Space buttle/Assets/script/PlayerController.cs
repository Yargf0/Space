using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : ShipBasic
{
    private Rigidbody2D rb2D;
    public static PlayerController Instance { get; private set; }
    public void Awake()
    {
        base.Awake();
        Instance =this;
        player = true;
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
    public Vector3 GetPostion()
    {
        return rb2D.transform.position;
    }

}
