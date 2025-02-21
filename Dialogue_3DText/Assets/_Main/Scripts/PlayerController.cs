using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 5.0f;          // �����ٶ�
    public float runSpeed = 8.0f;           // �����ٶ�
    public float sprintSpeed = 12.0f;       // ����ٶ�
    public float jumpForce = 5.0f;          // ��Ծ����
    public float gravity = -20.0f;          // ����
    public float mouseSensitivity = 2.0f;   // ���������
    public float lookSmoothness = 0.1f;     // �ӽ�ƽ����
    public Vector2 lookXLimit;        // �����ӽ�����

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

    public Transform groundCheck;           // �������
    public Transform playerCamera;          // ������

    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        currentSpeed = walkSpeed;
        //Cursor.lockState = CursorLockMode.Locked; // �������ָ��
        groundMask = LayerMask.GetMask("Ground"); // ����������Ϊ "Ground"
    }

    void Update()
    {
        // ����Ƿ��ڵ�����
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // ��΢���䣬��ֹ�����ٶȹ���
        }

        // ����ƶ�
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        // �л��ٶ�
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

        // ��Ծ
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(-2f * jumpForce * gravity);
        }

        // Ӧ������
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        // �������ӽ�
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        currentXRotation -= mouseY;
        currentXRotation = Mathf.Clamp(currentXRotation, lookXLimit.x, lookXLimit.y);

        playerCamera.localRotation = Quaternion.Euler(currentXRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }
}
