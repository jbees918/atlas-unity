using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpSpeed = 8f;
    public float gravity = 20f;

    private CharacterController characterController;
    private Vector3 moveDirection = Vector3.zero;

    private Vector3 startPosition;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        startPosition = transform.position;
    }

    void Movement()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalMovement, 0f, verticalMovement);
        movement = transform.TransformDirection(movement);
        movement *= moveSpeed;

        if (characterController.isGrounded) // Check if player is grounded
        {
            // apply jump
            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }

        // Apply gravity
        moveDirection.y -= gravity * Time.deltaTime;

        // Apply movement and grav
        characterController.Move(movement * Time.deltaTime + moveDirection * Time.deltaTime);
    }

    void Update()
    {
        Movement();
        if (transform.position.y < -30)
        {
            ResetPosition();
        }
    }

    private void ResetPosition()
    {
        transform.position = startPosition;
        moveDirection.y =  0;
    }
}