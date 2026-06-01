using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    [Header("Interaction")]
    [SerializeField] private float interactDistance = 3f;

    [SerializeField] private LayerMask interactLayer;

    private Camera playerCamera;

    private PlayerInputActions inputActions;

    private void Awake()
    {
        playerCamera =
            GetComponentInChildren<Camera>();

        inputActions = new PlayerInputActions();
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
        if (inputActions.Player.Interact.triggered)
        {
            TryInteract();
        }
    }

    private void TryInteract()
    {
        Ray ray =
            new Ray(
                playerCamera.transform.position,
                playerCamera.transform.forward
            );

        if (
            Physics.Raycast(
                ray,
                out RaycastHit hit,
                interactDistance,
                interactLayer
            )
        )
        {
            IInteractable interactable =
                hit.collider.GetComponentInParent<IInteractable>();

            if (interactable != null)
            {
                interactable.Interact();
            }
        }
    }
}