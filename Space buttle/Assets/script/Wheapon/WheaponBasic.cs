using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheaponBasic : MonoBehaviour
{
    [SerializeField] protected Wheapon wheapon;
    private bool reloadNow;
    [SerializeField] protected bool playerWheapon=false;
    //[SerializeField] private int rotateInt;
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
            if (spawned.GetComponent<Bullet>()!=null)
            {
                Bullet bullet = spawned.GetComponent<Bullet>();
                bullet.StartDestruction(wheapon.BulletExistence);
                bullet.Damage = wheapon.Damage;
                bullet.BulletSpeed = wheapon.BulletSpeed;
                bullet.PlayerBullet = playerWheapon;
            }           
            StartCoroutine(Reload(wheapon.RateOfFire));           
        }
    }
    public void Rotate(Vector3 position)
    {
        Vector3 diference = position - transform.position;
        float rotateZ = Mathf.Atan2(diference.y, diference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, 0f, (rotateZ + -90)), wheapon.RotationSpeed * Time.deltaTime);
    }
}
