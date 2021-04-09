using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Vector3 startPos;

    //placeHolder playerTrigger
    bool playerTrigger;
    
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTrigger == false)
        {
            EnemyMove();
        }
    }

    void EnemyMove()
    {

    }
}
