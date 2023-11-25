using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Vector3 = UnityEngine.Vector3;

public class Enemyai : MonoBehaviour
{
    [SerializeField] private int radiusOfDetection;
    [SerializeField] private int attackRadius;
    [SerializeField] private int rotationSpeed;
    private Rigidbody2D rb2D;
    public void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
    }
    public Vector3 GetCoordinateToMove(Vector3 vector)
    {
        float x1 = vector.x;
        float x2 = gameObject.transform.position.x;
        float y1 = vector.y;
        float y2 = gameObject.transform.position.y;
        float a = 2 * attackRadius * Mathf.Sin(0.5f * 15);
        //Mathf.Sqrt(Mathf.Pow(x2-x1, 2)+(Mathf.Pow( y2- y1, 2)));
        float x3 = x1 + attackRadius * Mathf.Cos(15) + attackRadius * Mathf.Sin(15);
        float y3 = y1 + attackRadius * Mathf.Cos(15) - attackRadius * Mathf.Sin(15);
        return new Vector3(x3, y3, 0);


    }
    private void FixedUpdate()
    {
        Collider2D[] colliderAray = Physics2D.OverlapCircleAll(gameObject.transform.position, radiusOfDetection);
        foreach (Collider2D collider2D in colliderAray)
        {
            if (collider2D.TryGetComponent<ShipBasic>(out ShipBasic ship))
            {
                if (ship.player == true)
                {                    
                    if((gameObject.transform.position - collider2D.transform.position).magnitude > attackRadius)
                    {
                        Rotate(collider2D.transform.position);
                        rb2D.AddForce(gameObject.transform.up * 130 * Time.deltaTime, ForceMode2D.Force);
                    }
                    else
                    {
                        Rotate(GetCoordinateToMove(collider2D.transform.position));
                        rb2D.AddForce(gameObject.transform.up * 70 * Time.deltaTime, ForceMode2D.Force);
                    }
                }
            }
        }
    }
    public void Rotate(Vector3 position)
    {
        Vector3 diference = position - transform.position;
        float rotateZ = Mathf.Atan2(diference.y, diference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, (rotateZ + -90));
    }
}
