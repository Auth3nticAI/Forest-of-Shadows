using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // The player's transform
    public float smoothSpeed = 0.125f; // The speed of the camera following the player
    public Vector3 offset; // The offset distance between the player and the camera

    void FixedUpdate()
    {
        if (target != null)
        {
            // Desired position for the camera
            Vector3 desiredPosition = target.position + offset;

            // Smoothly interpolate between the camera's current position and the desired position
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Update the camera's position
            transform.position = smoothedPosition;
        }
    }
}
