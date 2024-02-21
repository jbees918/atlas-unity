using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // Player's transform
    public float followSpeed = 5f; // Speed at which the camera follows the player
    public float rotationSpeed = 2f; // Speed of camera rotation

    private Vector3 offset; // Offset between camera and player

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.position; // Calculate initial offset
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer(); // Call method to follow player
        RotateCamera(); // Call method to rotate camera
    }

    void FollowPlayer()
    {
        Debug.Log("Following player"); // Check if method is being called
        Vector3 targetPosition = target.position + offset; // Calculate target position for camera
        Debug.Log("Target Position: " + targetPosition); // Log target position
        transform.position =
            Vector3.Lerp(transform.position, targetPosition,
                followSpeed * Time.deltaTime); // Smoothly move camera towards target position
        
    }

    void RotateCamera()
    {
        if (Input.GetMouseButton(1)) // Check if right mouse button is held down
        {
            float mouseX = Input.GetAxis("Mouse X"); // Get horizontal mouse movement
            float mouseY = Input.GetAxis("Mouse Y"); // Get vertical mouse movement

            Vector3 rotation = new Vector3(-mouseY, mouseX, 0f) * rotationSpeed; // Calculate rotation angles

            transform.Rotate(rotation); // Rotate camera
        }
    }
}