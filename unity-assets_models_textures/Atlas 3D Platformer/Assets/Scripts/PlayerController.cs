using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float jumpSpeed = 5f;
    
    CharacterController charactercontroller;
    public float ySpeed;
    public Transform startPosition;
    public float respawnHeight = -10f;
    public float respawnOffset = 2f;

    void Start()
    {
        charactercontroller = GetComponent<CharacterController>();
    }

    void Movement()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalMovement, 0f, verticalMovement) * moveSpeed;
        float magnitude = Mathf.Clamp01(movement.magnitude) * moveSpeed;
        movement.Normalize();

        charactercontroller.SimpleMove(movement * magnitude);
    }

    // Update is called once per frame
    private void Update()
    {
         Movement();
    }
}
