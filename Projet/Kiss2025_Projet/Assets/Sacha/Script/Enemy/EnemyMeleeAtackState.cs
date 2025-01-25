using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMeleeAtackState : EnemyBaseState
{
    public float meleeCooldown = 1.5f;
    private Animator enemyAnimatorrr;
    public override void EnterState(EnemyStateManager enemyState, Transform playerTransform, NavMeshAgent navMeshAgent, Animator animator, Transform weaponTransform, Animator enemyAnimator)
    {
        enemyAnimatorrr = enemyAnimator;
        enemyAnimatorrr.Play("AttackPirate");
        
        meleeCooldown = 1.5f;
        animator.SetTrigger("AnimationGo");
        RotateWeaponTowardsPlayer(weaponTransform, playerTransform.position);
    }

    

    public override void UpdateState(EnemyStateManager enemyState, Vector3 playerPosition, Vector3 enemyPosition)
    {
        if (meleeCooldown >= 0)
        {
            meleeCooldown -= Time.deltaTime;
        }
        else
        {
            enemyState.SwitchState(enemyState.movementState);
        }
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
    private void RotateWeaponTowardsPlayer(Transform weaponTransform, Vector3 playerPosition)
    {
        Vector3 directionToPlayer = (playerPosition - weaponTransform.position).normalized;
        
        Quaternion lookRotation = Quaternion.LookRotation(directionToPlayer);
        
        weaponTransform.rotation = Quaternion.Slerp(weaponTransform.rotation, lookRotation, 1f);
    }
}
