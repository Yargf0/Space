using UnityEngine;
using UnityEngine.UI;

public class ShipBasic : MonoBehaviour
{
    [SerializeField] protected Ship Ship;
    public bool Player=false;
    [HideInInspector]
    public float Hp;
    [SerializeField] protected Image hpSprite;
    public virtual void Awake()
    {       
        Hp =  Ship.Hp;
    }
    public virtual void ApplyDamage(float damage)
    {
        Hp -= damage;
        if (hpSprite!=null)
        {
            hpSprite.fillAmount = (Hp / Ship.Hp);
        }
            
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
