
using UnityEngine;

public class BaseState : MonoBehaviour
{
    [SerializeField] protected float Speed;
    [SerializeField] protected float AttackRadius;
    [SerializeField] protected Rigidbody2D rb2D;
    [SerializeField] protected GameObject me;
    [SerializeField] protected ParticleSystem engineParticle;
    public void Set(Enemy enemy, GameObject gameObject, ParticleSystem engineParticle)
    {
        Speed = enemy.Speed;
        AttackRadius = enemy.AttackRadius;
        me = gameObject;
        rb2D = me.GetComponent<Rigidbody2D>();
        this.engineParticle = engineParticle;
    }
    public virtual void Do()
    {
        engineParticle.Play();
        Rotate(PlayerController.Instance.transform.position);
        rb2D.AddForce(me.transform.up * Speed * Time.deltaTime, ForceMode2D.Force);
    }

    public void MoveTo(Vector3 position)
    {        
        Rotate(position);
        rb2D.AddForce(me.transform.up * Speed * Time.deltaTime, ForceMode2D.Force);
    }

    public void Rotate(Vector3 position)
    {
        Vector3 diference = position - me.transform.position;
        float rotateZ = Mathf.Atan2(diference.y, diference.x) * Mathf.Rad2Deg;
        me.transform.rotation = Quaternion.Euler(0f, 0f, rotateZ + -90);
    }
}
