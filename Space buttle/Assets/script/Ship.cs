using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Ship", menuName = "ScriptableObject/Ship")]
public class Ship : ScriptableObject
{
    public string Name;
    public float Hp;
    public float Speed;
    public float RotationSpeed;
}
