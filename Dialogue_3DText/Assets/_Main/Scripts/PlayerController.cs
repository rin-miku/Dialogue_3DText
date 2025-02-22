using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 5.0f;        
    public float runSpeed = 8.0f;         
    public float sprintSpeed = 12.0f;     
    public float jumpForce = 5.0f;        
    public float gravity = -20.0f;        
    public float mouseSensitivity = 2.0f; 
    public float lookSmoothness = 0.1f;   
    public Vector2 lookXLimit;            

    private float currentSpeed;
    private float currentGravity;
    private float currentXRotation = 0.0f;
    private bool isRunning = false;
    private bool isSprinting = false;

    private Vector3 velocity;
    private bool isGrounded;
    private float groundDistance = 0.4f;
    private float groundCheckRadius = 0.3f;
    private LayerMask groundMask;

    public Transform groundCheck;          
    public Transform playerCamera;          

    private CharacterController controller;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        currentSpeed = walkSpeed;
        groundMask = LayerMask.GetMask("Ground");
    }

    private void Update()
    {
        
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = sprintSpeed;
            isSprinting = true;
        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            currentSpeed = runSpeed;
            isRunning = true;
        }
        else
        {
            currentSpeed = walkSpeed;
            isRunning = false;
            isSprinting = false;
        }

        controller.Move(move * currentSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(-2f * jumpForce * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        currentXRotation -= mouseY;
        currentXRotation = Mathf.Clamp(currentXRotation, lookXLimit.x, lookXLimit.y);

        playerCamera.localRotation = Quaternion.Euler(currentXRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }
}
