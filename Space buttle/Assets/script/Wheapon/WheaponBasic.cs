using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WheaponBasic : MonoBehaviour
{
    [SerializeField] protected Wheapon wheapon;
    private bool reloadNow;
    [SerializeField] protected bool playerWheapon=false;
    [SerializeField] private List<Transform> spawnPpoint;

    public virtual void Start()
    {
        spawnPpoint = GetChilds();
    }
    public List<Transform> GetChilds()
    {
        List<Transform> ret = new List<Transform>();
        foreach (Transform child in gameObject.transform) ret.Add(child);
        return ret;
    }
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
        
            foreach (Transform barrol in spawnPpoint)
            {
                GameObject spawned = Instantiate(wheapon.Bullet, barrol.transform.position, gameObject.transform.rotation);
                if (spawned.GetComponent<Bullet>() != null)
                {                   
                    Bullet bullet = spawned.GetComponent<Bullet>();
                    bullet.Init(wheapon, playerWheapon);
                }
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
