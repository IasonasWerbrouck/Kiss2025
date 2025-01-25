using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class EnemyDeathState : EnemyBaseState
{
    
    public override void EnterState(EnemyStateManager enemyState, Transform playerTransform, NavMeshAgent navMeshAgent, Animator animator, Transform weaponTransform, Animator enemyAnimator)
    {
    }

    public override void UpdateState(EnemyStateManager enemyState, Vector3 playerPosition, Vector3 enemyPosition)
    {
    }

    public override void OnCollision(EnemyStateManager enemyState, Collider other)
    {

        other = null;
    }
    

    public override void ExitState(EnemyStateManager enemyState)
    {
    }
    public override void StunState(EnemyStateManager enemyState)
    {
    }
}
