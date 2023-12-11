using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObject/Enemy")]
public class Enemy : Ship
{
    [SerializeField] private int radiusOfDetection;
    [SerializeField] private int attackRadius;
    [SerializeField] private List<Wheapon> wheapons;

    public int RadiusOfDetection
    {
        get
        {
            return radiusOfDetection;
        }
    }
    public float AttackRadius
    {
        get
        {
            float i = 0;
            foreach (var wheapon in wheapons)
            {
                if (wheapon.RadiusOfFire > i)
                    i = wheapon.RadiusOfFire;
            }
            return i;
        }
    }

}
