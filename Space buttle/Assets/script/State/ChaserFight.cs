using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserFight : BaseState
{
    public override void Do()
    {
        Vector3 directionToTarget = PlayerController.Instance.transform.position - me.transform.position;
        Vector3 normalizedDirection = directionToTarget.normalized;
        Vector3 perpendicularDirection = Vector3.Cross(normalizedDirection, Vector3.up);

        if (perpendicularDirection.z < 0)
        {
            perpendicularDirection = -perpendicularDirection;
        }
        foreach (ParticleSystem particle in engineParticle)
        {
            particle.Play();
        }
        rb2D.AddForce(perpendicularDirection * Speed/10);
        Rotate(perpendicularDirection);

        rb2D.velocity = Vector3.ClampMagnitude(rb2D.velocity, Speed);

        if (rb2D.velocity.magnitude <= 0.8f)
        {
            foreach (ParticleSystem particle in engineParticle)
            {
                particle.Pause();
            }
        }
    }
}
