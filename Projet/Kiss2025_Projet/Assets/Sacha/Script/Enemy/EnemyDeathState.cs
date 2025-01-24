using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class EnemyDeathState : EnemyBaseState
{
    
    public override void EnterState(EnemyStateManager enemyState, Transform playerTransform, NavMeshAgent navMeshAgent)
    {
    }

    public override void UpdateState(EnemyStateManager enemyState, Vector3 playerPosition, Vector3 enemyPosition)
    {
    }

    public override void OnCollision(EnemyStateManager enemyState)
    {
    }

    public override void ExitState(EnemyStateManager enemyState)
    {
    }
}
