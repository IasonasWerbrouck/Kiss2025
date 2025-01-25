using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovementState : EnemyBaseState
{
    public NavMeshAgent agent;
    public Animator animatorEnemy;
    
    public override void EnterState(EnemyStateManager enemyState, Transform playerTransformv, NavMeshAgent navMeshAgent, Animator animator, Transform weaponTransform, Animator enemyAnimator)
    {
        agent = navMeshAgent;
        animatorEnemy = enemyAnimator;
        animatorEnemy.Play("WalkPirate");
    }

    public override void UpdateState(EnemyStateManager enemyState, Vector3 playerPosition, Vector3 enemyPosition)
    {
        
        agent.SetDestination(playerPosition);
        RaycastHit hit;
        Vector3 directionToPlayer = (playerPosition - enemyPosition).normalized;
        
        Ray PlayerRay = new Ray(enemyPosition, directionToPlayer);
        agent.isStopped = false;
        
        if (Physics.Raycast(PlayerRay, out hit, EnemyStateManager.detectionAreaMovement))
        {
            if (hit.collider.CompareTag("Player"))
            {
                agent.isStopped = true;
                enemyState.SwitchState(enemyState.MeleeAtackState);
            }
        }
        
        Debug.DrawRay(enemyPosition, directionToPlayer * EnemyStateManager.detectionAreaMovement, Color.yellow);
    }

    
    public override void OnCollision(EnemyStateManager enemyState, Collider other)
    {
        if (other.gameObject.CompareTag("Paralized"))
        {
            agent.isStopped = true;
            enemyState.SwitchState(enemyState.stunState);
        }

    }

    public override void ExitState(EnemyStateManager enemyState)
    {
        agent.isStopped = true;
    }
    public override void StunState(EnemyStateManager enemyState)
    {
    }
}
