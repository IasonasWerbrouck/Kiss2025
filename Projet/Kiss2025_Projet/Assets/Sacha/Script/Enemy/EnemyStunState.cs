using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStunState : EnemyBaseState
{
    public NavMeshAgent agent;
    public float timer = 3f;
    public override void EnterState(EnemyStateManager enemyState, Transform playerTransformv, NavMeshAgent navMeshAgent, Animator animator, Transform weaponTransform, Animator enemyAnimator)
    {
        enemyAnimator.Play("StunPirate");
        agent = navMeshAgent;
        agent.isStopped = true;
        enemyAnimator.Play("StunPirate");
        Debug.Log("stun");
    }

    public override void UpdateState(EnemyStateManager enemyState, Vector3 playerPosition, Vector3 enemyPosition)
    {
        if (timer >= 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            enemyState.SwitchState(enemyState.movementState); 
        }
        
    }

    public override void OnCollision(EnemyStateManager enemyState, Collider other)
    {
        if (other.gameObject.CompareTag("Paralized"))
        {
           
        }
    }

    public override void ExitState(EnemyStateManager enemyState)
    {
    }
    public override void StunState(EnemyStateManager enemyState)
    {
    }
}
