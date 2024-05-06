using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target; // Reference to the player's transform
    public Vector3 offset;   // Offset of the camera from the player


    private void Awake()
    {
        offset = transform.position - target.position;
    }
    void LateUpdate()
    {
        if (target != null)
        {
            // Set the camera's position to be the same as the player's position plus the offset
            transform.position = target.position + offset;
        }
    }
}