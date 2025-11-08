using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float mouseSensitivity = 2.0f;
    public float mouseDrag = 1.5f;

    private Transform character;
    private Vector2 mouseDirection;
    private Vector2 smoothing;
    private Vector2 result;

    private void Awake()
    {
        character = transform.root;
    }

    // Update is called once per frame
    void Update()
    {
        mouseDirection = new Vector2(Input.GetAxisRaw("Mouse X") * mouseSensitivity, Input.GetAxisRaw("Mouse Y") * mouseSensitivity);
        smoothing = Vector2.Lerp(smoothing, mouseDirection, 1 / mouseDrag);
        result += smoothing;

        // Clamping for gimble lock
        result.y = Mathf.Clamp(result.y, -20, 20);

        transform.localRotation = Quaternion.AngleAxis(-result.y, Vector3.right);
        character.rotation = Quaternion.AngleAxis(result.x, character.up);
    }
}
