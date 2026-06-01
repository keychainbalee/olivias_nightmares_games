using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitDoor : MonoBehaviour, IInteractable
{
    [SerializeField] private string requiredKey;

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
        SceneManager.LoadScene("EndingScene");
    }
}