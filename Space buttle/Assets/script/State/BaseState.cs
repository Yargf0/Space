using System.Collections.Generic;
using UnityEngine;

public class BaseState : MonoBehaviour
{
    protected Enemy enemy;
    protected float Speed;
    protected float AttackRadius;
    protected List<ParticleSystem> engineParticle;

    protected Rigidbody2D rb2D;
    protected GameObject me;

    public void Set(Enemy enemy, GameObject gameObject, List<ParticleSystem> engineParticle)
    {
        this.enemy = enemy;
        Speed = enemy.Speed;
        AttackRadius = enemy.AttackRadius;
        me = gameObject;
        rb2D = me.GetComponent<Rigidbody2D>();
        this.engineParticle = engineParticle;
    }
    public virtual void Do()
    {
        foreach (ParticleSystem particle in engineParticle)
        {
            particle.Play();
        }
        Rotate(PlayerController.Instance.transform.position);
        rb2D.AddForce(me.transform.up * Speed * Time.deltaTime, ForceMode2D.Force);
    }

    public virtual void MoveTo(Vector3 position)
    {        
        Rotate(position);
        rb2D.AddForce(me.transform.up * Speed * Time.deltaTime, ForceMode2D.Force);
    }

    public virtual void Rotate(Vector3 position)
    {
        Vector3 diference = position - me.transform.position;
        float rotateZ = Mathf.Atan2(diference.y, diference.x) * Mathf.Rad2Deg;
        me.transform.rotation = Quaternion.Euler(0f, 0f, rotateZ + -90);
    }
}
