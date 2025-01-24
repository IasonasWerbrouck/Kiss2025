using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovementState : EnemyBaseState
{
    public NavMeshAgent agent;
    private float detectionArea = 5;
    public override void EnterState(EnemyStateManager enemyState, Transform playerTransformv, NavMeshAgent navMeshAgent)
    {
        agent = navMeshAgent;
    }

    public override void UpdateState(EnemyStateManager enemyState, Vector3 playerPosition, Vector3 enemyPosition)
    {

        agent.SetDestination(playerPosition);
        RaycastHit hit;
        Vector3 directionToPlayer = (playerPosition - enemyPosition).normalized;
        
        Ray PlayerRay = new Ray(enemyPosition, directionToPlayer);
        agent.isStopped = false;
        
        if (Physics.Raycast(PlayerRay, out hit, detectionArea))
        {
            if (hit.collider.CompareTag("Player"))
            {
                agent.isStopped = true;
                enemyState.SwitchState(enemyState.MeleeAtackState);
            }
        }
        
        Debug.DrawRay(enemyPosition, directionToPlayer * detectionArea, Color.yellow);
    }
    
    public override void OnCollision(EnemyStateManager enemyState)
    {
    }

    public override void ExitState(EnemyStateManager enemyState)
    {
    }
}
