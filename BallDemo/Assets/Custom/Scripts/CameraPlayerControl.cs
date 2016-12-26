using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class CameraPlayerControl : MonoBehaviour
{
    public Transform lookAt;

    private Vector3 desiredPosition;
    private Vector3 offset;

    private float smoothSpeed = 7.5f;
    private float distance = 3f;
    private float yOffset = 3.5f;

    void Start()
    {
        offset = new Vector3(0, yOffset - 1, -2f*distance);
    }
    
    void Update()
    {
        if (CrossPlatformInputManager.GetButtonUp("TurnLeft"))
        {
            SlideCamera(0);
        }
        else if (CrossPlatformInputManager.GetButtonUp("TurnRight"))
        {
            SlideCamera(1);
        }
    }

    void FixedUpdate()
    {
        desiredPosition = lookAt.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.LookAt(lookAt.position);
    }

    void SlideCamera(int direction)
    {
        switch (direction)
        {
            case 0:
                offset = Quaternion.Euler(0, -45, 0) * offset;
                break;
            case 1:
                offset = Quaternion.Euler(0, 45, 0) * offset;
                break;
        }
    }

}
