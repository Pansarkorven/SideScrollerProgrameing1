using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    public Transform target;     // The target the camera should follow
    public float smoothSpeed = 0.125f; // The smoothness of camera movement

    private Vector3 offset;

    private void Start()
    {
        // Calculate the initial offset between the camera and the target
        offset = transform.position - target.position;
    }

    private void LateUpdate()
    {
        if (target != null)
        {
            // Calculate the desired position for the camera
            Vector3 desiredPosition = target.position + offset;

            // Smoothly interpolate the camera's position towards the desired position
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Update the camera's position
            transform.position = smoothedPosition;
        }
    }
}

