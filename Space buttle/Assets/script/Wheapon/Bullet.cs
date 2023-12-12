using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    protected float damage;
    protected float speed;
    public bool PlayerBullet;
    public Wheapon wheapon;
    public virtual void Activate()
    {
        damage = wheapon.Damage;
        speed = wheapon.BulletSpeed;
        gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * speed);

    }
    public virtual void StartDestruction(float time)
    {
        StartCoroutine(WhaitDestroy(time));
    }
    public virtual IEnumerator WhaitDestroy(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent <ShipBasic>(out ShipBasic ship))
        {
            if (ship.Player != PlayerBullet)
            {
                ship.ApplyDamage(damage);
                Destroy(gameObject);
            }
        }
    }
}
