using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    //change when you get the class for player
    Vector3 PlayerLocation = new Vector3(0, 0, 0);

    Vector3 EnemyLocation = new Vector3(-2,1,-4);

    
    public enum AIState { IDLE, PATROL, ATTACK};

    AIState state = AIState.PATROL;

    NavMeshAgent agent;

 
    //Enemy Speed
    public float speed = 2;
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

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
                Patrol(Time.deltaTime, EnemyLocation);
                break;
            case AIState.ATTACK:
                Patrol(Time.deltaTime, PlayerLocation);
                break;
        }
    }
    void Idle(float delta)
    {
        //This needs to have come back to after I get the player class and i can pull the location
        if (PlayerLocation == EnemyLocation);
        {
            state = AIState.ATTACK;
        }
    }

    void Patrol(float delta, Vector3 Destination)
    {
        agent.Move(Destination*delta*speed);
    }
}
