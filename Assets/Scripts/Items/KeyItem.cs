using UnityEngine;

public class KeyItem : MonoBehaviour, IInteractable
{
    [SerializeField] private string keyID;

    private InventorySystem inventory;

    private void Start()
    {
        inventory =
            FindFirstObjectByType<InventorySystem>();
    }

    public void Interact()
    {
        inventory.AddKey(keyID);

        Destroy(gameObject);
    }
}