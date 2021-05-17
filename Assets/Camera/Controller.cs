using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    private InputHandler input;

    private bool crouch;

    private double CrouchSpeed;

    private double Speed = 1;

    void Start()
    {
        input = InputHandler.instance;
    }

    void Update()
    {
        handleCrouch();
    }

    private void handleCrouch()
    {
        if(crouch == true)
        {
            Vector3 crouchScale = new Vector3(1, .5f, 1);
            transform.localScale = crouchScale;
        
            CrouchSpeed = Speed * .75;
        }
    }
    
}
