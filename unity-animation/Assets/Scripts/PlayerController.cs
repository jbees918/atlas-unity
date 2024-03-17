using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpSpeed = 8f;
    public float gravity = 20f;
    public float rotationSpeed = 4f;

    private CharacterController characterController;
    private Vector3 moveDirection = Vector3.zero;
    
    private Camera mainCamera; // Reference to the main camera
    private Vector3 forwardDirection; // Forward direction of the camera

    private Vector3 startPosition;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        startPosition = transform.position;
        
        mainCamera = Camera.main;
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
    
    void RotatePlayer(Vector3 forwardDirection)
    {
        // Rotate the player to face the camera's forward direction
        if (forwardDirection != Vector3.zero)
        {
            Vector3 horizontalForward = Vector3.ProjectOnPlane(forwardDirection, Vector3.up).normalized;
            Quaternion newRotation = Quaternion.LookRotation(horizontalForward);
            // Debug.Log("New Rotation: " + newRotation.eulerAngles);
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * rotationSpeed);
        }
    }

    void Update()
    {
        Movement();
        
        // Get the forward direction of the main camera
        if (mainCamera != null)
        {
            forwardDirection = mainCamera.transform.forward;
            RotatePlayer(forwardDirection); // Rotate the player based on the camera's forward direction
        }
        
        if (transform.position.y < -30)
        {
            ResetPosition();
        }
    }

    private void ResetPosition()
    {
        moveDirection.y =  0f;
        StartCoroutine(RespawnPlayer());
    }
    
    IEnumerator RespawnPlayer()
    {
        yield return new WaitForSeconds(0.01f); // Adjust the delay as needed
        transform.position = startPosition + Vector3.up * 76f;
        moveDirection = Vector3.zero;
    }
}