using UnityEngine;
using UnityEngine.UI;

public class FlashlightController : MonoBehaviour
{
    [Header("Flashlight")]
    [SerializeField] private GameObject flashlightLight;

    [Header("Dependencies")]
    [SerializeField] private InventorySystem inventory;
    [SerializeField] private InventorySwitcher inventorySwitcher;

    [Header("UI")]
    [SerializeField] private Button powerButton;
    [SerializeField] private Sprite powerOnSprite;
    [SerializeField] private Sprite powerOffSprite;

    private Image buttonImage;

    private void Awake()
    {
        buttonImage = powerButton.GetComponent<Image>();

        if (inventory == null)
            inventory = FindFirstObjectByType<InventorySystem>();
    }

    private void Start()
    {
        flashlightLight.SetActive(false);

        UpdateButtonIcon();
    }

    public void ToggleFlashlight()
    {
        // Belum memiliki senter
        if (!inventory.HasFlashlight())
            return;

        // Slot aktif harus slot senter
        if (inventorySwitcher.GetCurrentSlot() != 1)
            return;

        bool newState = !flashlightLight.activeSelf;

        flashlightLight.SetActive(newState);

        UpdateButtonIcon();

        Debug.Log(newState ? "Flashlight ON" : "Flashlight OFF");
    }

    public void ForceTurnOff()
    {
        flashlightLight.SetActive(false);

        UpdateButtonIcon();
    }

    public bool IsFlashlightOn()
    {
        return flashlightLight.activeSelf;
    }

    private void UpdateButtonIcon()
    {
        if (buttonImage == null)
            return;

        buttonImage.sprite =
            flashlightLight.activeSelf ?
            powerOnSprite :
            powerOffSprite;
    }
}