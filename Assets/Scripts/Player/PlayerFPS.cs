using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerFPS : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float walkSpeed = 4f;
    [SerializeField] private float sprintSpeed = 7f;
    [SerializeField] private float crouchSpeed = 2f;
    [SerializeField] private float gravity = -20f;

    [Header("Mouse Look")]
    [SerializeField] private float mouseSensitivity = 2f;

    [Header("Crouch")]
    [SerializeField] private float standingHeight = 2f;
    [SerializeField] private float crouchHeight = 1f;

    private CharacterController controller;
    private Camera playerCamera;

    private PlayerInputActions inputActions;

    private Vector2 moveInput;
    private Vector2 lookInput;

    private float cameraRotationX;
    private float verticalVelocity;

    private bool isSprinting;
    private PlayerStamina staminaSystem;
    private bool isCrouching;

    private void Awake()
    {

        controller = GetComponent<CharacterController>();
        playerCamera = GetComponentInChildren<Camera>();
        inputActions = new PlayerInputActions();
        staminaSystem = GetComponent<PlayerStamina>();
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    private void Update()
    {
        ReadInput();
        HandleMouseLook();
        HandleMovement();
        HandleCrouch();
    }

    private void ReadInput()
    {
        moveInput = inputActions.Player.Move.ReadValue<Vector2>();
        lookInput = inputActions.Player.Look.ReadValue<Vector2>();

        isSprinting = inputActions.Player.Sprint.IsPressed();
        isCrouching = inputActions.Player.Crouch.IsPressed();
    }

    private void HandleMovement()
    {
        float currentSpeed = walkSpeed;

        if (isSprinting && staminaSystem.CanSprint())
        {
            currentSpeed = sprintSpeed;

            staminaSystem.UseStamina();
        }

        if (isCrouching)
        {
            currentSpeed = crouchSpeed;
        }

        Vector3 move =
            transform.right * moveInput.x +
            transform.forward * moveInput.y;

        controller.Move(move * currentSpeed * Time.deltaTime);

        if (controller.isGrounded && verticalVelocity < 0)
        {
            verticalVelocity = -2f;
        }

        verticalVelocity += gravity * Time.deltaTime;

        Vector3 gravityMove =
            Vector3.up * verticalVelocity;

        controller.Move(gravityMove * Time.deltaTime);
    }

    private void HandleMouseLook()
    {
        float mouseX = lookInput.x * mouseSensitivity;
        float mouseY = lookInput.y * mouseSensitivity;

        cameraRotationX -= mouseY;

        cameraRotationX =
            Mathf.Clamp(cameraRotationX, -80f, 80f);

        playerCamera.transform.localRotation =
            Quaternion.Euler(cameraRotationX, 0, 0);

        transform.Rotate(Vector3.up * mouseX);
    }

    private void HandleCrouch()
    {
        controller.height =
            isCrouching ? crouchHeight : standingHeight;
    }
}