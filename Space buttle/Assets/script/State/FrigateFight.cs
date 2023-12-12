using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FrigateFight : BaseState
{
    public override void Do()
    {
        foreach (ParticleSystem particle in engineParticle)
        {
            particle.Play();
        }
        Rotate(PlayerController.Instance.transform.position);
    }
    public override void Rotate(Vector3 position)
    {
        
        Vector3 diference = position - transform.position;
        float rotateZ = Mathf.Atan2(diference.y, diference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, 0f, (rotateZ + -90)), enemy.RotationSpeed * Time.deltaTime/3);
        Debug.Log(transform.rotation);
    }
}
