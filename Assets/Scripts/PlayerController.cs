using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float walkingSpeed = 5.0f;
    public float sprintSpeed = 10.0f;
    public float crouchSpeed = 2.0f;
    public float gravity = 2.0f;
    public float jumpForce = 0.3f;

    private float currentSpeed = 0;
    private float velocity = 0;
    private CharacterController controller;
    private Vector3 motion;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentSpeed = walkingSpeed;            // Sets to walking speed on load in automatically.
    }

    // Update is called once per frame
    void Update()
    {
        motion = Vector3.zero;

        if (controller.isGrounded == true)
        {
            velocity = -gravity * Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.Space) == true)
            {
                velocity = jumpForce;
            }
            else if (Input.GetKeyDown(KeyCode.LeftShift) == true)
            {
                if (currentSpeed != sprintSpeed)
                {
                    currentSpeed = sprintSpeed;
                }
            }
            else if (Input.GetKeyUp(KeyCode.LeftShift) == true)
            {
                if (currentSpeed != walkingSpeed)
                {
                    currentSpeed = walkingSpeed;
                }
            }
        }
        else
        {
            velocity -= gravity * Time.deltaTime;
        }
        ApplyMovement();
    }

    void ApplyMovement()
    {
        motion += transform.forward * Input.GetAxisRaw("Vertical") * currentSpeed * Time.deltaTime;
        motion += transform.right * Input.GetAxisRaw("Horizontal") * currentSpeed * Time.deltaTime;
        motion.y += velocity;

        if (controller.enabled)
        {
            controller.Move(motion);
        }
    }
}
