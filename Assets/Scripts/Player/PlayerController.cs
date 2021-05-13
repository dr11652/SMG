using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private InputManager input;

    private CharacterController controller;

    private Rigidbody player;

    private CharacterController crouch;

    #region HandlingGravity
    [SerializeField]
    private Transform groundCheck;
    [SerializeField]
    private float gravity = -9.81f;
    [SerializeField]
    private Vector3 velocity;
    [SerializeField]
    private LayerMask groundMask;
    [SerializeField]
    private float groundDistance = .4f;
    [SerializeField]
    private bool grounded = false;
    [SerializeField]
    private float jumpHeight = 3f;
    #endregion
   
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        input = InputManager.instance;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        HandleMovement(Time.deltaTime);
        HandleGravity(Time.deltaTime);
        HandleJump();
    }
    private void HandleMovement(float delta)
    {
        Vector3 movement = (input.move.x * transform.right) + (input.move.y * transform.forward);
        controller.Move(movement * 5 * Time.deltaTime);

    }

    private void HandleGravity(float delta)
    {
        grounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(grounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * delta;
        controller.Move(velocity * delta);

    }

    private void HandleJump()
    {
        if(input.jumpDown && grounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    private void HandleCrouch()
    {

    }

}
