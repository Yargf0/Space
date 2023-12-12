using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wheapon", menuName = "ScriptableObject/Wheapon")]
public class Wheapon : ScriptableObject
{
    [SerializeField] private string name;
    [SerializeField] private float damage;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float rateOfFire;
    [SerializeField] private float radiusOfFire;
    [SerializeField] private float bulletExistence;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private GameObject bullet;
    public string Name
    {
        get
        {
            return name;
        }
    }
    public float Damage
    {
        get
        {
            return damage;
        }
    }
    public float RotationSpeed
    {          
        get         
        { 
            return rotationSpeed; 
        } 
    }
    public float RateOfFire
    {
        get
        {
            return rateOfFire;
        }
    }
    public float RadiusOfFire
    {
        get
        {
            return radiusOfFire;
        }
    }
    public float BulletExistence
    {
        get
        {
            return bulletExistence;
        }
    }
    public float BulletSpeed
    {
        get
        {
            return bulletSpeed;
        }
    }
    public GameObject Bullet
    {
        get
        {
            return bullet;
        }
    }
    

}
