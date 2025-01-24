using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateManager : MonoBehaviour
{
    EnemyBaseState currentState;
    private EnemyDeathState deathState = new EnemyDeathState();
    private EnemyIdleState IdleState = new EnemyIdleState();
    private EnemyMovementState movementState = new EnemyMovementState();
    private EnemyMeleeAtackState MeleeAtackState = new EnemyMeleeAtackState();
    
    
    // Start is called before the first frame update
    void Start()
    {
        currentState = IdleState;
        
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }
}
