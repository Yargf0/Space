using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheaponBasic : MonoBehaviour
{
    public Wheapon wheapon;
    private bool reloadNow;
    [SerializeField] private int rotateInt;
    [SerializeField] private GameObject spawnPpoint;

    private IEnumerator Reload(float time)
    {
        reloadNow = true;
        yield return new WaitForSeconds(time);
        reloadNow = false;
    }
    public void Shoot()
    {
        if (reloadNow!=true)
        {
            GameObject spawned= Instantiate(wheapon.Bullet, spawnPpoint.transform.position, gameObject.transform.rotation);
            Bullet bullet = spawned.GetComponent<Bullet>();
            bullet.StartDestruction(wheapon.BulletExistence);
            bullet.Damage = wheapon.Damage;
            bullet.BulletSpeed = wheapon.BulletSpeed;
            StartCoroutine(Reload(wheapon.RateOfFire));           
        }
    }
    public void Rotate(Vector3 position)
    {
        Vector3 diference = position - transform.position;
        float rotateZ = Mathf.Atan2(diference.y, diference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ + rotateInt);
    }
}
