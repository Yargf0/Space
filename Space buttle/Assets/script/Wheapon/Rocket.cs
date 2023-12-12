using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : Bullet
{
    [SerializeField] private ParticleSystem engineParticle;
    private Rigidbody2D rb2D;
    private float rotationSpeed;
    [SerializeField] private float boomRadius;

    private void Awake()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    public override void Init(Wheapon wheapon, bool isPlayerBullet)
    {
        engineParticle.Play();       

        Wheapon = wheapon;

        damage = Wheapon.Damage;
        speed = Wheapon.BulletSpeed;
        rotationSpeed = Wheapon.RotationSpeed;

        PlayerBullet = isPlayerBullet;

        StartCoroutine(DestroyWithDelay(wheapon.BulletExistence));
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (PlayerController.Instance == null)
            return;
        Rotate(PlayerController.Instance.transform.position);
        rb2D.AddForce(gameObject.transform.up * speed * Time.deltaTime, ForceMode2D.Force);
    }
    private void Rotate(Vector3 position)
    {
        Vector3 diference = position - transform.position;
        float rotateZ = Mathf.Atan2(diference.y, diference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, 0f, (rotateZ + -90)), rotationSpeed * Time.deltaTime);
    }

    public override void Destroy()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(gameObject.transform.position, boomRadius);
        foreach (Collider2D collider in colliders)
        {
            if (collider.TryGetComponent<ShipBasic>(out ShipBasic ship))
            {
                ship.ApplyDamage(damage);
                
            }
        }
        Destroy(gameObject);
    }
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out ShipBasic ship))
        {
            if (ship.Player)
            {
                Destroy();
            }
        }
    }
}
