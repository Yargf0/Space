using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    protected float damage;
    protected float speed;
    public bool PlayerBullet;
    public Wheapon Wheapon;

    public virtual void Init(Wheapon wheapon, bool isPlayerBullet)
    {
        Wheapon = wheapon;
        damage = Wheapon.Damage;
        speed = Wheapon.BulletSpeed;
        PlayerBullet = isPlayerBullet;

        StartCoroutine(DestroyWithDelay(wheapon.BulletExistence));
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector2.up * speed * Time.fixedDeltaTime);
    }

    public virtual IEnumerator DestroyWithDelay(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy();
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

    public virtual void Destroy()
    {
        Destroy(gameObject);
    }
}
