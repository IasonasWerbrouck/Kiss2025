using UnityEngine;

public abstract class EnemyBaseState
{
    abstract public void EnterState(EnemyStateManager enemyState);
    
    abstract public void UpdateState(EnemyStateManager enemyState);
    
    abstract public void OnCollision(EnemyStateManager enemyState);
    
    abstract public void ExitState(EnemyStateManager enemyState);

}
