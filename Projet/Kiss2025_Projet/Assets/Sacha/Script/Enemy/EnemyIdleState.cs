using UnityEngine;
using UnityEngine.AI;

public class EnemyIdleState : EnemyBaseState
{

    private float detectionArea = 20;
    public override void EnterState(EnemyStateManager enemyState, Transform playerTransform, NavMeshAgent navMeshAgent)
    {
        
    }

    public override void UpdateState(EnemyStateManager enemyState, Vector3 playerPosition, Vector3 enemyPosition)
    {
        RaycastHit hit;
        Vector3 directionToPlayer = (playerPosition - enemyPosition).normalized;
        
        Ray PlayerRay = new Ray(enemyPosition, directionToPlayer);
        
        if (Physics.Raycast(PlayerRay, out hit, detectionArea))
        {
            if (hit.collider.CompareTag("Player"))
            {
                enemyState.SwitchState(enemyState.movementState);
            }
        }
        
        Debug.DrawRay(enemyPosition, directionToPlayer * detectionArea, Color.green);
    }


    public override void OnCollision(EnemyStateManager enemyState)
    {
    }

    public override void ExitState(EnemyStateManager enemyState)
    {
    }
}
