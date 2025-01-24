using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStateManager : MonoBehaviour
{
    public static float meleeCooldown;
    public Transform weaponTransform;
    public static float detectionAreaIdle = 20;
    public static float detectionAreaMovement = 5;
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
        
        currentState = idleState;
        
        currentState.EnterState(this, playerTrasform, agent, animator, weaponTransform);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Stunned = true;
        }
        if (Stunned)
        {
            StartCoroutine(StunCouldown());
            currentState.ExitState(this);
            
        }
        else
        {
         currentState.UpdateState(this,playerTrasform.position, transform.position);
         
            
        }
    }

    IEnumerator StunCouldown()
    {
        
        currentState = stunState;
        agent.isStopped = true;
        yield return new WaitForSeconds(3f);
        currentState = movementState;
        agent.isStopped = false;
        Stunned = false;
    }
    public void SwitchState(EnemyBaseState state)
    {
        currentState = state;
        state.EnterState(this, playerTrasform, agent, animator, weaponTransform);
    }
}
