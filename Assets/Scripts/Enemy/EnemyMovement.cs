using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    //change when you get the class for player
    public Transform playerLocation;

    public Transform enemyLocation;

    
    public enum AIState { IDLE, PATROL, ATTACK};

    AIState state = AIState.PATROL;

    NavMeshAgent agent;
    public Transform[] goals;
    public int patrolTarget = 0;
    

    //Enemy Speed
    public float speed = 2;
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(goals[0].position);
    }

    // Update is called once per frame
    void Update()
    {

        switch (state)
        {
            case AIState.IDLE:
                //Animation of the zombie
                Idle(Time.deltaTime);
                break;
            case AIState.PATROL:
                Patrol();
                break;
            case AIState.ATTACK:
               // Patrol(Time.deltaTime, PlayerLocation);
                break;
        }
    }
    void Idle(float delta)
    {
        //This needs to have come back to after I get the player class and i can pull the location
        if (playerLocation == enemyLocation);
        {
            state = AIState.ATTACK;
        }
    }

    void Patrol()
    {
            if (agent.remainingDistance > .2f)
            {
                agent.SetDestination(goals[patrolTarget].position);
            }
            else if (patrolTarget >= 4)
            {
                patrolTarget = -1;
            }
            else
            {
                patrolTarget++;
                agent.SetDestination(goals[patrolTarget].position);
            }
        

        Debug.Log(state);
        Debug.Log(agent.remainingDistance);
    }
}
