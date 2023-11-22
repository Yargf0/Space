using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wheapon", menuName = "ScriptableObject/Wheapon")]
public class Wheapon : ScriptableObject
{
    public string Name;
    public float Damage;
    public float RateOfFire;
    public float RadiusOfFire;
    public float BulletExistence;
    public float BulletSpeed;
    public GameObject Bullet;

}
