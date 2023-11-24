using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Damage;
    public float BulletSpeed;
    public bool PlayerBullet;
    private void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * BulletSpeed);
    }
    public void StartDestruction(float time)
    {
        StartCoroutine(Destroy(time));
    }
    private IEnumerator Destroy(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent <ShipBasic>(out ShipBasic ship))
        {
            if (ship.player != PlayerBullet)
            {
                ship.Damage(Damage);
                Destroy(gameObject);
            }
        }
    }
}
