using System.Collections.Generic;
using UnityEngine.Events;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator; // Assign in inspector
    public Transform orientation;
    public Transform player;
    public Transform playerObj;
    public Rigidbody rb;
    
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
        
        Vector3 targetDirection = new Vector3(horizontalMovement, 0f, verticalMovement).normalized;
        Vector3 currentDirection = new Vector3(moveDirection.x, 0f, moveDirection.z).normalized;

        // Smoothly interpolate between the current direction and the target direction
        Vector3 smoothDirection = Vector3.Lerp(currentDirection, targetDirection, Time.deltaTime * rotationSpeed);

        // Calculate the final movement vector based on the smoothed direction and move speed
        Vector3 movement = smoothDirection * moveSpeed;

        // Adjust moveDirection for gravity and apply jump logic if needed
        if (characterController.isGrounded)
        {
            moveDirection = new Vector3(movement.x, moveDirection.y, movement.z);
            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }
        else
        {
            moveDirection.x = movement.x;
            moveDirection.z = movement.z;
        }

        // Apply gravity
        moveDirection.y -= gravity * Time.deltaTime;

        // Move the character controller
        characterController.Move(moveDirection * Time.deltaTime);
    }
    
    void RotatePlayer(Vector3 forwardDirection)
    {
        // Rotate the player to face the camera's forward direction
        if (forwardDirection != Vector3.zero)
        {
            Vector3 horizontalForward = Vector3.ProjectOnPlane(forwardDirection, Vector3.up).normalized;
            Quaternion newRotation = Quaternion.LookRotation(horizontalForward);
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * rotationSpeed);
        }
    }

    void Update()
    {
        Movement();
        HandleAnimation();
        
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
    
    void HandleAnimation()
    {
        // Get input from arrow keys or WASD
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // Determine the direction and set the Animator parameters
        if (Mathf.Abs(horizontal) > Mathf.Abs(vertical))
        {
            animator.SetFloat("MoveX", horizontal);
            animator.SetFloat("MoveY", 0);
        }
        else
        {
            animator.SetFloat("MoveX", 0);
            animator.SetFloat("MoveY", vertical);
        }
    }

    private void ResetPosition()
    {
        moveDirection.y = 0f;
        StartCoroutine(RespawnPlayer());
    }
    
    IEnumerator RespawnPlayer()
    {
        yield return new WaitForSeconds(0.01f); // Adjust the delay as needed
        transform.position = startPosition + Vector3.up * 76f;
        moveDirection = Vector3.zero;
    }
}
