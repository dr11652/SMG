using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    //change when you get the class for player
    Vector3 PlayerLocation = new Vector3(0, 0, 0);

    Vector3 EnemyLocation = new Vector3();


    //
    public enum AIState { IDLE, PATROL, ATTACK};

    AIState state = AIState.IDLE;

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

                break;
            case AIState.PATROL:
                Patrol(Time.deltaTime);
                break;
        }
    }
    void Idle()
    {
        if(10 != 9)
        {
            state = AIState.ATTACK;
        }
    }

    void Patrol(float delta)
    {

    }
}
