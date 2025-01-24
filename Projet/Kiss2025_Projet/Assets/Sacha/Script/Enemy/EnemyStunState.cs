using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStunState : EnemyBaseState
{
    public NavMeshAgent agent;
    public override void EnterState(EnemyStateManager enemyState, Transform playerTransformv, NavMeshAgent navMeshAgent, Animator animator, Transform weaponTransform)
    {
        agent = navMeshAgent;
        agent.isStopped = true;
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
    public override void StunState(EnemyStateManager enemyState)
    {
    }
}
