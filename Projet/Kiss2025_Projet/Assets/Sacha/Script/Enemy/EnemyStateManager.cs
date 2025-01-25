using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStateManager : MonoBehaviour
{
    public Animator enemyAnimator;
    public Collider collider;
    public static float meleeCooldown;
    public Transform weaponTransform;
    public static float detectionAreaIdle = 20;
    public static float detectionAreaMovement = 3;
    public Animator animator;
    public NavMeshAgent agent;
    EnemyBaseState currentState;
    public Transform playerTrasform;
    public EnemyDeathState deathState = new EnemyDeathState();
    public EnemyIdleState idleState = new EnemyIdleState();
    public EnemyMovementState movementState = new EnemyMovementState();
    public EnemyMeleeAtackState MeleeAtackState = new EnemyMeleeAtackState();
    public EnemyStunState stunState = new EnemyStunState();
    public bool Stunned = false;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator> ();
        agent = GetComponent<NavMeshAgent>();
        playerTrasform = GameObject.FindGameObjectWithTag("Player").transform;
        
        currentState = movementState;
        
        currentState.EnterState(this, playerTrasform, agent, animator, weaponTransform, enemyAnimator);
    }

    // Update is called once per frame
    void Update()
    {
            currentState.UpdateState(this,playerTrasform.position, transform.position);
    }
    
    public void SwitchState(EnemyBaseState state)
    {
        currentState = state;
        state.EnterState(this, playerTrasform, agent, animator, weaponTransform, enemyAnimator);
    }

    public void OnTriggerEnter(Collider one)
    {
        currentState.OnCollision(this, one);
        
    }
}
