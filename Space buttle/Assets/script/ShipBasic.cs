using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipBasic : MonoBehaviour
{
    public Ship ship;
    public bool player=false;
    private float Hp;
    [SerializeField] Image HpSprite;
    public void Awake()
    {        
        Hp =  ship.Hp;
    }
    public void Damage(float damage)
    {
        Debug.Log(ship.Name);
        Hp -= damage;
        HpSprite.fillAmount = (Hp / ship.Hp);
        if (Hp < 0)
        {
            Destroy();
        }
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }



}
