using UnityEngine;

public class DoorController : MonoBehaviour, IInteractable
{
    [Header("Door Settings")]
    [SerializeField] private string requiredKey;

    [SerializeField] private bool isLocked = true;

    [SerializeField] private bool isOpen = false;

    [SerializeField] private float openAngle = 90f;

    [SerializeField] private float openSpeed = 3f;

    [Tooltip("Centang jika pintu membuka ke kanan")]
    [SerializeField] private bool openToRight = true;

    private Quaternion closedRotation;
    private Quaternion openRotation;

    private InventorySystem inventory;

    public bool IsOpen => isOpen;

    private void Start()
    {
        inventory = FindFirstObjectByType<InventorySystem>();

        // Simpan rotasi awal PivotDoor
        closedRotation = transform.localRotation;

        float angle = openToRight ? openAngle : -openAngle;

        // Rotasi tujuan
        openRotation = closedRotation * Quaternion.Euler(0, angle, 0);
    }

    private void Update()
    {
        Quaternion targetRotation = isOpen ? openRotation : closedRotation;

        transform.localRotation = Quaternion.Slerp(
            transform.localRotation,
            targetRotation,
            openSpeed * Time.deltaTime
        );
    }

    public void Interact()
    {
        if (isLocked)
        {
            if (inventory != null && inventory.HasKey(requiredKey))
            {
                UnlockDoor();
            }
            else
            {
                if (DoorUI.Instance != null)
                {
                    DoorUI.Instance.ShowLockedMessage();
                }
                else
                {
                    Debug.Log("Door Locked");
                }
            }
        }
        else
        {
            ToggleDoor();
        }
    }

    private void UnlockDoor()
    {
        isLocked = false;
        ToggleDoor();
    }

    private void ToggleDoor()
    {
        isOpen = !isOpen;
    }
}