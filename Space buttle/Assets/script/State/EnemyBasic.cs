using UnityEngine;
using UnityEngine.UI;

public class EnemyBasic : ShipBasic
{
    [SerializeField] protected Enemy enemy;
    public override void Awake()
    {
        Hp = enemy.Hp;
    }
    public override void ApplyDamage(float damage)
    {
        Hp -= damage;
        if (hpSprite != null)
        {
            Debug.Log(Hp);
            hpSprite.fillAmount = (Hp / enemy.Hp);
        }

        if (Hp < 0)
        {
            Destroy();
        }
    }
}
