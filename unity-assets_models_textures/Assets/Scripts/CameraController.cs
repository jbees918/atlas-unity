using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public Transform target; // Player's transform
    public float followSpeed = 5f; // Speed at which the camera follows the player
    public float rotationSpeed = 2f; // Speed of camera rotation
    
    public Vector3 offset; // Offset between cam and player
    public Vector3 velocity = Vector3.zero; // Velocity
    
    private Vector3 forwardDirection; // Forward direction of  cam
    void Start()
    {
      //  offset = transform.position - target.position; // Calculates initial offset
    }

    void LateUpdate()
    {
        Rotate();
       transform.position = player.position + offset;
       transform.LookAt(player.transform.position);
    }

    void Rotate()
    {
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
        Quaternion horizontalRotation = Quaternion.AngleAxis(mouseX, Vector3.up);
        offset = horizontalRotation * offset;
    }
}