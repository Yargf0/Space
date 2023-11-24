using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

[CreateAssetMenu(fileName ="Ship", menuName = "ScriptableObject/Ship")]
public class Ship : ScriptableObject
{
    [SerializeField] private string name;
    [SerializeField] private float hp;
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;

    public string Name
    {
        get
        {
            return name;
        }
    }
    public float Hp
    {
        get
        {
            return hp;
        }
    }
    public float Speed
    {
        get
        {
            return speed;
        }
    }
    public float RotationSpeed
    {
        get
        {
            return rotationSpeed;
        }
    }
}
