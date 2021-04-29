using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    //change when you get the class for player
    public Transform playerLocation;

    public Transform enemyLocation;

    public float idleTimer = 0;
    
    public enum AIState { IDLE, PATROL, ATTACK};

    AIState state = AIState.IDLE;

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
                Idle();
                break;
            case AIState.PATROL:
                Patrol();
                break;
            case AIState.ATTACK:
               // Patrol(Time.deltaTime, PlayerLocation);
                break;
        }
    }
    void Idle()
    {
        //This needs to have come back to after I get the player class and i can pull the location
        agent.isStopped = true;
        if (agent.remainingDistance <= 5)
        {
            agent.isStopped = false;
            state = AIState.ATTACK;
        } else
        {
            idleTimer += Time.deltaTime;
            if(idleTimer > 5)
            {
                agent.isStopped = false;
                state = AIState.PATROL;
                idleTimer = 0;
            }
        }

        Debug.Log(idleTimer);
        Debug.Log(state);
        Debug.Log(agent.remainingDistance);
       
    }

    void Patrol()
    {
        if (agent.remainingDistance > .2f)
        {
            agent.SetDestination(goals[patrolTarget].position);
        }
        else
        { 
            //Make Random
            int rand = Random.Range(0, 3);
            patrolTarget = rand;
            agent.SetDestination(playerLocation.position);
            state = AIState.IDLE;
            
           
        }
        

        Debug.Log(state);
        Debug.Log(agent.remainingDistance);
        Debug.Log(patrolTarget);
    }
}
