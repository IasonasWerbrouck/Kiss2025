using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStateManager : MonoBehaviour
{
    public NavMeshAgent agent;
    EnemyBaseState currentState;
    public Transform playerTrasform;
    public EnemyDeathState deathState = new EnemyDeathState();
    public EnemyIdleState idleState = new EnemyIdleState();
    public EnemyMovementState movementState = new EnemyMovementState();
    public EnemyMeleeAtackState MeleeAtackState = new EnemyMeleeAtackState();
    
    
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        playerTrasform = GameObject.FindGameObjectWithTag("Player").transform;
        
        currentState = idleState;
        
        currentState.EnterState(this, playerTrasform, agent);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this,playerTrasform.position, transform.position);
    }

    public void SwitchState(EnemyBaseState state)
    {
        currentState = state;
        state.EnterState(this, playerTrasform, agent);
    }
}
