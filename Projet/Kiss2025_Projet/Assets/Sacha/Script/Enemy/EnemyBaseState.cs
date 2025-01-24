using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyBaseState
{
    abstract public void EnterState(EnemyStateManager enemyState, Transform playerTransform, NavMeshAgent navMeshAgent);
    
    abstract public void UpdateState(EnemyStateManager enemyState, Vector3 playerPosition, Vector3 enemyPosition);
    
    abstract public void OnCollision(EnemyStateManager enemyState);
    
    abstract public void ExitState(EnemyStateManager enemyState);

}
