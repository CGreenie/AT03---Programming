using UnityEngine;
using UnityEngine.UIElements;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset = new Vector3(0f, 2f, -5f);   // Position behind player
    public float smoothSpeed = 0.125f;                  // Smoother interpolation

    private void LateUpdate()                           // Late update for movement to happen first
    {
        Vector3 desiredPosition = player.position + player.rotation * offset;                           // Follows the movement and applies offset
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(player.position);              // Cam looks at player
    }

}
