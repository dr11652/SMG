using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Vector3 startPos;
    public CharacterController enemy;
    //placeHolder playerTrigger
    bool playerTrigger;
    
    void Start()
    {
        enemy = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTrigger == false)
        {
            EnemyMove(Time.deltaTime);
        }
    }

    void EnemyMove(float delta)
    {
        float x = Random.Range(-1f, 1f);
        float z = Random.Range(-1f, 1f);

        Vector3 move = new Vector3(x, 0, z);
        enemy.Move(move * delta*2);
    }
}
