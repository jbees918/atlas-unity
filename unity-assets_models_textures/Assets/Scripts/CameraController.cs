using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // Player's transform
    public float followSpeed = 5f; // Speed at which the camera follows the player
    public float rotationSpeed = 2f; // Speed of camera rotation
    public float smoothTime = 0.3f; // Smooth time for SmoothDamp
    public float maxDistance = Mathf.Infinity; // Maximum distance for ClampMagnitude

    private Vector3 offset; // Offset between camera and player
    private Vector3 velocity = Vector3.zero; // Velocity reference for SmoothDamp

    void Start()
    {
        offset = transform.position - target.position; // Calculate initial offset
    }

    void Update()
    {
        FollowPlayer(); // Call method to follow player
        RotateCamera(); // Call method to rotate camera
    }

    void FollowPlayer()
    {
        Vector3 targetPosition = target.position + offset; // Calculate target position for camera
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime); // Smoothly move camera towards target position
        transform.position = Vector3.ClampMagnitude(transform.position, maxDistance); // Clamp camera position to prevent overshooting
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