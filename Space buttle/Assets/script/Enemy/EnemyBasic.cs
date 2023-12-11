using UnityEngine;
using UnityEngine.UI;

public class EnemyBasic : ShipBasic
{
    [SerializeField] protected Enemy enemy;
    public override void Awake()
    {
        Hp = enemy.Hp;
        maxHp = Hp;
    }
}
