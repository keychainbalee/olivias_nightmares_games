using UnityEngine;

public class ExitDoor : MonoBehaviour, IInteractable
{
    [Header("Door")]
    [SerializeField] private string requiredKey;

    [Header("Level Complete")]
    [SerializeField] private LevelComplete levelComplete;

    private InventorySystem inventory;

    private void Start()
    {
        inventory =
            FindFirstObjectByType<InventorySystem>();
    }

    public void Interact()
    {
        if (inventory.HasKey(requiredKey))
        {
            WinGame();
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

    private void WinGame()
    {
        if (levelComplete != null)
        {
            levelComplete.CompleteLevel();
        }
        else
        {
            Debug.LogWarning("LevelComplete belum di-assign.");
        }
    }
}