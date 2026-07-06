using UnityEngine;

public class DoorController : MonoBehaviour, IInteractable
{
    [Header("Key")]
    [SerializeField] private string requiredKey = "ExitKey";

    [Header("Door")]
    [SerializeField] private bool isLocked = true;

    [Tooltip("Centang saat Play Mode untuk membuka pintu.")]
    [SerializeField] private bool isOpen = false;

    [SerializeField] private float openAngle = 90f;
    [SerializeField] private float openSpeed = 180f;

    [SerializeField] private bool openToRight = true;

    private Quaternion closedRotation;
    private Quaternion openedRotation;
    private int interactCount = 0;

    private InventorySystem inventory;

    private void Awake()
    {
        inventory = FindFirstObjectByType<InventorySystem>();
    }

    private void Start()
    {
        closedRotation = transform.localRotation;

        float angle = openToRight ? openAngle : -openAngle;

        openedRotation =
            Quaternion.Euler(
                closedRotation.eulerAngles.x,
                closedRotation.eulerAngles.y + angle,
                closedRotation.eulerAngles.z
            );
    }

    private void Update()
    {
        Quaternion target = isOpen ? openedRotation : closedRotation;

        transform.localRotation = Quaternion.RotateTowards(
            transform.localRotation,
            target,
            openSpeed * Time.deltaTime
        );
    }

    public void Interact()
    {
        interactCount++;

        if (isLocked)
        {
            if (inventory != null && inventory.HasKey(requiredKey))
            {
                isLocked = false;
                isOpen = true;

                Debug.Log("Door Unlocked");
            }
            else
            {
                if (DoorUI.Instance != null)
                {
                    DoorUI.Instance.ShowLockedMessage();
                }

                return;
            }
        }
        else
        {
            isOpen = !isOpen;
        }
    }

    [ContextMenu("Open Door")]
    private void OpenDoor()
    {
        isOpen = true;
    }

    [ContextMenu("Close Door")]
    private void CloseDoor()
    {
        isOpen = false;
    }
}