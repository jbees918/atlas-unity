using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpSpeed = 5f;
    public float gravity = 20f; // Gravity affecting the player

    private CharacterController characterController;
    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Movement()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalMovement, 0f, verticalMovement);
        movement = transform.TransformDirection(movement); // Convert movement relative to player's orientation
        movement *= moveSpeed;

        // Apply gravity
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }
        else
        {
            moveDirection.y = 0; // Reset y-speed when grounded
        }

        // Jump
        if (characterController.isGrounded && Input.GetButtonDown("Jump"))
        {
            moveDirection.y = jumpSpeed;
        }

        // Apply movement
        characterController.Move(movement * Time.deltaTime);
        characterController.Move(moveDirection * Time.deltaTime);
    }

    void Update()
    {
        Movement();
    }
}