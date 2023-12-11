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
        engineParticle.Play();
        rb2D.AddForce(perpendicularDirection * Speed);
        Rotate(perpendicularDirection);

        rb2D.velocity = Vector3.ClampMagnitude(rb2D.velocity, Speed);
    }
}
