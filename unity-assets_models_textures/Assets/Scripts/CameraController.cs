using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public Transform target; // Player's transform
    public float followSpeed = 5f; // Speed at which the camera follows the player
    public float rotationSpeed = 2f; // Speed of camera rotation
    
    public Vector3 offset; // Offset between camera and player
    public Vector3 velocity = Vector3.zero; // Velocity reference
    void Start()
    {
      //  offset = transform.position - target.position; // Calculate initial offset
    }

    void LateUpdate()
    {
        Rotate();
       transform.position = player.position + offset;
       transform.LookAt(player.transform.position);
    }

    void Rotate()
    {
        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotationSpeed, Vector3.up) * offset;
    }
}