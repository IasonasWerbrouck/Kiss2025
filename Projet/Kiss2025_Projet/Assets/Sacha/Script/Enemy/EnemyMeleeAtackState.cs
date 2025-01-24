using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMeleeAtackState : EnemyBaseState
{
    private float meleeCooldown;
    public override void EnterState(EnemyStateManager enemyState, Transform playerTransform, NavMeshAgent navMeshAgent)
    {
    }

    public override void UpdateState(EnemyStateManager enemyState, Vector3 playerPosition, Vector3 enemyPosition)
    {
        if (meleeCooldown >= 0)
        {
            
        }
    }

    public override void OnCollision(EnemyStateManager enemyState)
    {
    }

    public override void ExitState(EnemyStateManager enemyState)
    {
    }
}
