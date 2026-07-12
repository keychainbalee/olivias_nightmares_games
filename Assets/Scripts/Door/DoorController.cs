using UnityEngine;

public class DoorController : MonoBehaviour, IInteractable
{
    [Header("Key")]
    [SerializeField] private string requiredKey = "ExitKey";

    [Header("Door")]
    [SerializeField] private bool isLocked = true;

    [Tooltip("Status pintu saat Play Mode")]
    [SerializeField] private bool isOpen = false;

    [SerializeField] private float openAngle = 90f;

    [SerializeField] private float openSpeed = 180f;

    [SerializeField] private bool openToRight = true;

    [Header("Audio")]
    [SerializeField] private DoorAudio doorAudio;

    private Quaternion closedRotation;
    private Quaternion openedRotation;

    private InventorySystem inventory;

    private void Awake()
    {
        inventory = FindFirstObjectByType<InventorySystem>();
    }

    private void Start()
    {
        closedRotation = transform.localRotation;

        float angle = openToRight ? openAngle : -openAngle;

        openedRotation = Quaternion.Euler(
            closedRotation.eulerAngles.x,
            closedRotation.eulerAngles.y + angle,
            closedRotation.eulerAngles.z
        );
    }

    private void Update()
    {
        Quaternion targetRotation =
            isOpen ? openedRotation : closedRotation;

        transform.localRotation =
            Quaternion.RotateTowards(
                transform.localRotation,
                targetRotation,
                openSpeed * Time.deltaTime
            );
    }

    public void Interact()
    {
        // Jika pintu masih terkunci
        if (isLocked)
        {
            // Belum memiliki kunci
            if (inventory == null || !inventory.HasKey(requiredKey))
            {
                DoorUI.Instance?.ShowLockedMessage();
                return;
            }

            // Memiliki kunci
            isLocked = false;
            isOpen = true;

            doorAudio?.PlayDoorSound();

            return;
        }

        // Toggle pintu
        isOpen = !isOpen;

        doorAudio?.PlayDoorSound();
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