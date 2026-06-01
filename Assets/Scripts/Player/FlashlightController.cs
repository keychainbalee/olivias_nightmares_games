using UnityEngine;

public class FlashlightController : MonoBehaviour
{
    [SerializeField] private GameObject flashlight;

    private PlayerInputActions inputActions;

    private InventorySystem inventory;

    private bool isOn;

    private void Awake()
    {
        inputActions = new PlayerInputActions();
    }

    private void Start()
    {
        inventory =
            FindFirstObjectByType<InventorySystem>();
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    private void Update()
    {
        if (
            inputActions.Player.Flashlight.triggered &&
            inventory.HasFlashlight()
        )
        {
            ToggleFlashlight();
        }
    }

    private void ToggleFlashlight()
    {
        isOn = !isOn;

        flashlight.SetActive(isOn);
    }
}