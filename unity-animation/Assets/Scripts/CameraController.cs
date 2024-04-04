using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Camera myCamera;
    [SerializeField] float ySpeed = -0.01f, xSpeed = 1;


    public bool isInverted = false;
    Vector3 Offset, rotOffset;
    float viewAngle = 0, playerRotation;
    // Start is called before the first frame update
    void Start()
    {
        if (myCamera == null)
            myCamera = Camera.main;
        if (PlayerPrefs.HasKey("Y_Invert"))
            isInverted = PlayerPrefs.GetInt("Y_Invert") == 1;
        Offset = myCamera.transform.position - transform.position;
        rotOffset = myCamera.transform.rotation.eulerAngles - transform.rotation.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        int invert = 1;
        if (isInverted)
            invert = -1;
        viewAngle += Input.GetAxis("Mouse Y") * ySpeed * invert;
        viewAngle = Mathf.Clamp(viewAngle, 0, 90f);
        //transform.Rotate(0, Input.GetAxis("Mouse X") * xSpeed, 0);
        playerRotation += Input.GetAxis("Mouse X");
        myCamera.transform.position =  (transform.position +  Quaternion.Euler(viewAngle, playerRotation, 0) * Offset);
        myCamera.transform.rotation = Quaternion.Euler((Vector3.up * playerRotation) + rotOffset + (Vector3.right * viewAngle));
        
    }

    
    public Vector3 GetDirection()
    {
        return (Vector3.up * playerRotation);
    }
}