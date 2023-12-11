using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : ShipBasic
{
    public static PlayerController Instance { get; private set; }
    private Rigidbody2D rb2D;
    public void Awake()
    {
        base.Awake();
        Instance =this;
        Player = true;
        rb2D = gameObject.GetComponent<Rigidbody2D>();
    }
    public void FixedUpdate()
    {
        if(Input.GetKey("w"))
        {                
            rb2D.AddForce(gameObject.transform.up * Ship.Speed * Time.deltaTime, ForceMode2D.Force);
        }
        if (Input.GetKey("s"))
        {
            rb2D.AddForce(-gameObject.transform.up * Ship.Speed * Time.deltaTime, ForceMode2D.Force);
        }
        if (Input.GetKey("a"))  
        {
            rb2D.MoveRotation(rb2D.rotation+ Ship.RotationSpeed * Time.fixedDeltaTime);

        }
        if (Input.GetKey("d"))
        {
            rb2D.MoveRotation(rb2D.rotation - Ship.RotationSpeed * Time.fixedDeltaTime);
        }
    }

}
