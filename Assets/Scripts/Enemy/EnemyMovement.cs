using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Transform playerLocation;

    public Transform enemyLocation;

    public float idleTimer = 0;

    public enum AIState { IDLE, PATROL, ATTACK };

    public AIState state = AIState.PATROL;

    NavMeshAgent agent;
    public Transform[] goals;
    public int patrolTarget = 0;

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
        //increment timer as long as timer less than something
        if(idleTimer < 5)
        {
            agent.isStopped = true;
            idleTimer += Time.deltaTime;
        } else
        {
            agent.isStopped = false; //free up agent
            patrolTarget = Random.Range(0, goals.Length); //choose a goal
            agent.SetDestination(goals[patrolTarget].position); //send agent to new goal
            state = AIState.PATROL; //swap states
            idleTimer = 0; //reset timer
        }

        //if timer runs out, switch to patrol, set a patrol destination

        Debug.Log(idleTimer);
        Debug.Log(state);
        Debug.Log(agent.remainingDistance);
       
    }

    void Patrol()
    {
        if (agent.remainingDistance < .2f)
        {
            //Make Random
            state = AIState.IDLE;
        }
        
        Debug.Log(agent.remainingDistance);
    }
}
