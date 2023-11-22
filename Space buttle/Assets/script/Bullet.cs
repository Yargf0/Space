using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Damage;
    public float BulletSpeed;
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
}
