using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    public float lookRadius = 10f;

    Transform target;
    NavMeshAgent agent;
    CharacterCombat combat;

    private BaseEnemyAnimator baseEnemyAnimator;

    private float wanderSpeed = 2f;
    public float normalSpeed;
    public int roamRadius = 70;


    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        combat = GetComponent<CharacterCombat>();
        normalSpeed = agent.speed;
        baseEnemyAnimator = GetComponent<BaseEnemyAnimator>();
    }



    void Update()
    {
        // Distance to the target
        float distance = Vector3.Distance(target.position, transform.position);



        //if not inside the lookRadius
        if (distance >= lookRadius)
        {
            agent.speed = wanderSpeed;
            baseEnemyAnimator.IsWandering();
        }



        // If inside the lookRadius
        if (distance <= lookRadius)
        {
            // Move towards the target
            agent.SetDestination(target.position);
            agent.speed = normalSpeed;
            baseEnemyAnimator.IsNotWandering();

            // If within attacking distance
            if (distance <= agent.stoppingDistance)
            {
                CharacterStats targetStats = target.GetComponent<CharacterStats>();
                if (targetStats != null)
                {
                    combat.Attack(targetStats);
                }

                FaceTarget();   // Make sure to face towards the target
            }
        }
    }

    // Rotate to face the target
    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }




    // Show the lookRadius in editor
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

}