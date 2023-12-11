
using UnityEngine;

public class BaseState : MonoBehaviour
{
    public float Speed;
    public float AttackRadius;
    public Rigidbody2D rb2D;
    public GameObject me;

    public void Set(Enemy enemy, Ship ship, GameObject gameObject )
    {
        Speed = ship.Speed;
        AttackRadius = enemy.AttackRadius;
        me = gameObject;
        rb2D = me.GetComponent<Rigidbody2D>();
    }
    public virtual void Do()
    {
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
