using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : ShipBasic
{ 
    public static PlayerController Instance { get; private set; }
    private Rigidbody2D rb2D;
    [SerializeField] private List<ParticleSystem> engineParticle;
    [SerializeField] private float axeleration;
    [SerializeField] private Image staminaSprite;
    [Range(0,100)][SerializeField] private float stamina;
    private float maxStamina;

    public override void Awake()
    {
        Hp = Ship.Hp;
        maxHp = Hp;

        maxStamina = stamina;

        Instance =this;
        Player = true;
        rb2D = gameObject.GetComponent<Rigidbody2D>();
    }

    public void FixedUpdate()
    {
        float ax = 1;
        stamina += 0.1f;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (stamina > 1)
            {
                ax = axeleration;
                stamina -= 0.3f;
            }
        }
        if (staminaSprite != null)
        {
            staminaSprite.fillAmount = (stamina / maxStamina);
        }

        if (Input.GetKey("w"))
        {                
            rb2D.AddForce(gameObject.transform.up * Ship.Speed * ax * Time.deltaTime, ForceMode2D.Force);
        }
        if (Input.GetKey("s"))
        {
            rb2D.AddForce(-gameObject.transform.up * Ship.Speed * ax * 0.6f * Time.deltaTime, ForceMode2D.Force);
        }
        if (Input.GetKey("a"))  
        {
            rb2D.MoveRotation(rb2D.rotation+ Ship.RotationSpeed * Time.fixedDeltaTime);
        }
        if (Input.GetKey("d"))
        {
            rb2D.MoveRotation(rb2D.rotation - Ship.RotationSpeed * Time.fixedDeltaTime);
        }
        if (rb2D.velocity.magnitude <= 0.8f)
        {
            foreach (ParticleSystem particle in engineParticle)
            {
                particle.Pause();
            }
        }
        else
        {
            foreach (ParticleSystem particle in engineParticle)
            {
                particle.Play();
            }
        }
    }

}
