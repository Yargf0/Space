using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : Bullet
{
    [SerializeField] private ParticleSystem engineParticle;
    private Rigidbody2D rb2D;
    private float rotationSpeed;
    [SerializeField] private float boomRadius;


    // Start is called before the first frame update
    public override void Activate()
    {
        rb2D=gameObject.GetComponent<Rigidbody2D>();

        engineParticle.Play();       
        damage = wheapon.Damage;
        speed = wheapon.BulletSpeed ;
        rotationSpeed = wheapon.RotationSpeed;
    }

    // Update is called once per frame
    void Update()
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
    public override IEnumerator WhaitDestroy(float time)
    {
        yield return new WaitForSeconds(time);
        Expload();

    }
    private void Expload()
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
                Debug.Log("1");
                Expload();
            }
        }
    }




}
