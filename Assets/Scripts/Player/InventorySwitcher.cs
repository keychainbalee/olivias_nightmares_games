using UnityEngine;
using UnityEngine.UI;

public class InventorySwitcher : MonoBehaviour
{
    [Header("Inventory Objects")]
    [SerializeField] private GameObject flashlightObject;
    [SerializeField] private GameObject keyObject;

    [Header("UI Buttons")]
    [SerializeField] private Button handButton;
    [SerializeField] private Button flashlightButton;
    [SerializeField] private Button keyButton;
    [SerializeField] private Button flashlightPowerButton;

    private InventorySystem inventory;

    private int currentSlot;

    private void Start()
    {
        inventory = FindFirstObjectByType<InventorySystem>();

        SelectSlot(0);

        RefreshUI();
    }

    private void Update()
    {
        RefreshUI();
    }

    private void RefreshUI()
    {
        flashlightButton.gameObject.SetActive(
            inventory.HasFlashlight());

        keyButton.gameObject.SetActive(
            inventory.HasAnyKey());

        flashlightPowerButton.gameObject.SetActive(
            inventory.HasFlashlight() && currentSlot == 1);
    }

    public void SelectHand()
    {
        SelectSlot(0);
    }

    public void SelectFlashlight()
    {
        if (!inventory.HasFlashlight())
            return;

        SelectSlot(1);
    }

    public void SelectKey()
    {
        if (!inventory.HasAnyKey())
            return;

        SelectSlot(2);
    }

    private void SelectSlot(int slot)
    {
        currentSlot = slot;

        flashlightObject.SetActive(false);
        keyObject.SetActive(false);

        switch (currentSlot)
        {
            case 1:

                flashlightObject.SetActive(true);

                break;

            case 2:

                keyObject.SetActive(true);

                break;
        }

        RefreshUI();
    }

    public int GetCurrentSlot()
    {
        return currentSlot;
    }
}