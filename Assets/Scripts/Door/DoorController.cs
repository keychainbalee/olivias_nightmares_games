using UnityEngine;

public class DoorController : MonoBehaviour, IInteractable
{
    [Header("Door Settings")]
    [SerializeField] private string requiredKey;

    [SerializeField] private bool isLocked = true;

    [SerializeField] private bool isOpen;

    [SerializeField] private float openAngle = 90f;

    [SerializeField] private float openSpeed = 3f;

    private Quaternion closedRotation;
    private Quaternion openRotation;

    private InventorySystem inventory;

    private void Start()
    {
        inventory =
            FindFirstObjectByType<InventorySystem>();

        closedRotation = transform.rotation;

        openRotation =
            Quaternion.Euler(
                transform.eulerAngles +
                new Vector3(0, -openAngle, 0)
            );
    }

    private void Update()
    {
        Quaternion targetRotation =
            isOpen ? openRotation : closedRotation;

        transform.rotation =
            Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                openSpeed * Time.deltaTime
            );
    }

    public void Interact()
    {
        if (isLocked)
        {
            if (inventory.HasKey(requiredKey))
            {
                OpenDoor();
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

    private void OpenDoor()
    {
        isLocked = false;

        ToggleDoor();
    }

    private void ToggleDoor()
    {
        isOpen = !isOpen;
    }
}