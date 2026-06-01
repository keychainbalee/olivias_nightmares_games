using UnityEngine;

public class FlashlightItem : MonoBehaviour, IInteractable
{
    private InventorySystem inventory;

    [SerializeField] private GameObject flashlightObject;

    private void Start()
    {
        inventory =
            FindFirstObjectByType<InventorySystem>();
    }

    public void Interact()
    {
        inventory.AddFlashlight();

        flashlightObject.SetActive(true);

        Destroy(gameObject);
    }
}