using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitySampleAssets.CrossPlatformInput;
using UnityStandardAssets.CrossPlatformInput;

public class CameraPlayerControl : MonoBehaviour
{
    public Transform lookAt;

    public float smoothSpeed = 7.5f;
    public float distance = 5.5f;
    public float yOffset = 2.5f;
    public float turnAngle = 30;

    private Vector3 desiredPosition;
    private Vector3 offset;

    void Start()
    {
        offset = new Vector3(0, yOffset, -distance);
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
                offset = Quaternion.Euler(0, -turnAngle, 0) * offset;
                break;
            case 1:
                offset = Quaternion.Euler(0, turnAngle, 0) * offset;
                break;
        }
    }

}
