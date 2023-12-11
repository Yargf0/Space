using UnityEngine;
public abstract class EnemyBaseStat
{
    public abstract void EnterState(EnemyStateManager enemyManager);

    public abstract void StateUpdate();

}
