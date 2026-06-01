using UnityEngine;

public class InventorySwitcher : MonoBehaviour
{
    [Header("Inventory Slots")]
    [SerializeField] private GameObject flashlightObject;

    [SerializeField] private GameObject keyObject;

    private int currentSlot;
    private InventorySystem inventory;

    private void Start()
    {
        SelectSlot(0);
        inventory = FindFirstObjectByType<InventorySystem>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectSlot(0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SelectSlot(1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SelectSlot(2);
        }
    }

    private void SelectSlot(int slot)
    {
        currentSlot = slot;

        flashlightObject.SetActive(false);
        keyObject.SetActive(false);

        switch (currentSlot)
        {
            case 0:
                break;

            case 1:

                if (inventory.HasFlashlight())
                {
                    flashlightObject.SetActive(true);
                }

                break;

            case 2:

                if (inventory.HasAnyKey())
                {
                    keyObject.SetActive(true);
                }

                break;
        }
    }
}