using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObject/Enemy")]
public class Enemy : ScriptableObject
{
    [SerializeField] private string name;
    [SerializeField] private int radiusOfDetection;
    [SerializeField] private int attackRadius;
    [SerializeField] private int rotationSpeed;
    [SerializeField] private int speed;

    public string Name
    {
        get
        {
            return name;
        }
    }
    public int RadiusOfDetection
    {
        get
        {
            return radiusOfDetection;
        }
    }
    public int AttackRadius
    {
        get
        {
            return attackRadius;
        }
    }
    public int RotationSpeed
    {
        get
        {
            return rotationSpeed;
        }
    }
    public int Speed
    {
        get
        {
            return speed;
        }
    }
}
