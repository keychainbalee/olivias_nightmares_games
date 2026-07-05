using UnityEngine;

public class ExitDoor : MonoBehaviour, IInteractable
{
    [SerializeField] private string requiredKey;

    [SerializeField] private DoorController doorController;

    private InventorySystem inventory;

    private void Start()
    {
        inventory = FindFirstObjectByType<InventorySystem>();
    }

    public void Interact()
    {
        if (inventory.HasKey(requiredKey))
        {
            doorController.Interact();
        }
        else
        {
            if (DoorUI.Instance != null)
                DoorUI.Instance.ShowLockedMessage();
        }
    }
}