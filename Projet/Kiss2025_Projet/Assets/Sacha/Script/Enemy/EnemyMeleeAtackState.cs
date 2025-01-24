using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMeleeAtackState : EnemyBaseState
{
    public float meleeCooldown = 1.5f;
    private Animator enemyAnimator;
    public override void EnterState(EnemyStateManager enemyState, Transform playerTransform, NavMeshAgent navMeshAgent, Animator animator, Transform weaponTransform)
    {
        enemyAnimator = animator;
        
        meleeCooldown = 1.5f;
        enemyAnimator.SetTrigger("AnimationGo");
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

    public override void OnCollision(EnemyStateManager enemyState)
    {
    }

    public override void ExitState(EnemyStateManager enemyState)
    {
        
    }
    public override void StunState(EnemyStateManager enemyState)
    {
    }
    private void RotateWeaponTowardsPlayer(Transform weaponTransform, Vector3 playerPosition)
    {
        // Calculate the direction from the weapon to the player
        Vector3 directionToPlayer = (playerPosition - weaponTransform.position).normalized;

        // Calculate the rotation needed to look at the player
        Quaternion lookRotation = Quaternion.LookRotation(directionToPlayer);

        // Apply the rotation to the weapon
        weaponTransform.rotation = Quaternion.Slerp(weaponTransform.rotation, lookRotation, Time.deltaTime * 10f);
    }
}
