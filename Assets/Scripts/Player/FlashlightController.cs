using UnityEngine;

public class FlashlightController : MonoBehaviour
{
    [SerializeField] private GameObject flashlight;
    [SerializeField] private InventorySwitcher switcher;

    private InventorySystem inventory;

    private bool isOn;

    private void Start()
    {
        inventory = FindFirstObjectByType<InventorySystem>();
    }

    public void ToggleFlashlight()
    {
        if (!inventory.HasFlashlight())
            return;

        if (switcher.GetCurrentSlot() != 1)
            return;

        isOn = !isOn;

        flashlight.SetActive(isOn);
    }
}