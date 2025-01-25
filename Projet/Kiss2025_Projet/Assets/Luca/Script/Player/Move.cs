using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Move : MonoBehaviour{
    private NavMeshAgent navMeshAgent;
    private Vector3 movementDirection;
    public Animator animator;
    private bool mouving;

    void Awake(){
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (navMeshAgent == null) return;

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        if (moveHorizontal != 0 || moveVertical != 0)
        {
            mouving = true;
        }

        movementDirection = new Vector3(moveHorizontal, 0.0f, moveVertical);
        if (movementDirection != Vector3.zero)
        {
            navMeshAgent.SetDestination(transform.position + movementDirection);
        }

        if (Input.GetKey(KeyCode.Z))
        {
            movementDirection = Vector3.forward;
            navMeshAgent.SetDestination(transform.position + Vector3.forward);
        }

        if (Input.GetKey(KeyCode.S))
        {
            movementDirection = Vector3.back;
            navMeshAgent.SetDestination(transform.position + Vector3.back);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            movementDirection = Vector3.left;
            navMeshAgent.SetDestination(transform.position + Vector3.left);
        }

        if (Input.GetKey(KeyCode.D))
        {
            movementDirection = Vector3.right;
            navMeshAgent.SetDestination(transform.position + Vector3.right);
        }

        if (navMeshAgent.velocity != Vector3.zero)
        {
            animator.SetBool("Moving", true);
            mouving = true;
        }
        else
        {
            animator.SetBool("Moving", false);
            mouving = false;
        }
    }

    public Vector3 GetMovementDirection(){
        return movementDirection;
    }
}
