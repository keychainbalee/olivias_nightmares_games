using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float walkSpeed = 4f;
    [SerializeField] private float sprintSpeed = 7f;
    [SerializeField] private float gravity = -20f;

    [Header("Look")]
    [SerializeField] private float lookSensitivity = 0.2f;

    private CharacterController controller;
    private Camera playerCamera;
    private PlayerStamina staminaSystem;

    private Vector2 moveInput;
    private Vector2 lookInput;

    private float verticalVelocity;
    private float cameraRotationX;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        playerCamera = GetComponentInChildren<Camera>();
        staminaSystem = GetComponent<PlayerStamina>();
    }

    private void Update()
    {
        HandleLook();
        HandleMovement();
    }

    //--------------------------------------------------
    // Dipanggil dari UI
    //--------------------------------------------------

    public void SetMoveInput(Vector2 input)
    {
        moveInput = input;
    }

    public void SetLookInput(Vector2 input)
    {
        lookInput = input;
    }

    //--------------------------------------------------

    private void HandleMovement()
    {
        float magnitude = moveInput.magnitude;

        float speed = walkSpeed;

        if (magnitude >= 0.7f && staminaSystem.CanSprint())
        {
            speed = sprintSpeed;
            staminaSystem.UseStamina();
        }

        Vector3 move =
            transform.right * moveInput.x +
            transform.forward * moveInput.y;

        controller.Move(move * speed * Time.deltaTime);

        if (controller.isGrounded && verticalVelocity < 0)
        {
            verticalVelocity = -2f;
        }

        verticalVelocity += gravity * Time.deltaTime;

        controller.Move(
            Vector3.up * verticalVelocity * Time.deltaTime
        );
    }

    private void HandleLook()
    {
        float mouseX = lookInput.x * lookSensitivity;
        float mouseY = lookInput.y * lookSensitivity;

        cameraRotationX -= mouseY;
        cameraRotationX = Mathf.Clamp(cameraRotationX, -80f, 80f);

        playerCamera.transform.localRotation =
            Quaternion.Euler(cameraRotationX, 0, 0);

        transform.Rotate(Vector3.up * mouseX);
    }
}