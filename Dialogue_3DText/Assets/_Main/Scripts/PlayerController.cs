using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 5.0f;          // 步行速度
    public float runSpeed = 8.0f;           // 奔跑速度
    public float sprintSpeed = 12.0f;       // 冲刺速度
    public float jumpForce = 5.0f;          // 跳跃力度
    public float gravity = -20.0f;          // 重力
    public float mouseSensitivity = 2.0f;   // 鼠标灵敏度
    public float lookSmoothness = 0.1f;     // 视角平滑度
    public Vector2 lookXLimit;        // 上下视角限制

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

    public Transform groundCheck;           // 地面检测点
    public Transform playerCamera;          // 玩家相机

    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        currentSpeed = walkSpeed;
        //Cursor.lockState = CursorLockMode.Locked; // 锁定鼠标指针
        groundMask = LayerMask.GetMask("Ground"); // 假设地面层名为 "Ground"
    }

    void Update()
    {
        // 检测是否在地面上
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // 轻微下落，防止下落速度过快
        }

        // 玩家移动
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        // 切换速度
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

        // 跳跃
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(-2f * jumpForce * gravity);
        }

        // 应用重力
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        // 鼠标控制视角
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        currentXRotation -= mouseY;
        currentXRotation = Mathf.Clamp(currentXRotation, lookXLimit.x, lookXLimit.y);

        playerCamera.localRotation = Quaternion.Euler(currentXRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }
}
