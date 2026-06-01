using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private Slider staminaSlider;

    private PlayerStamina stamina;

    private void Start()
    {
        stamina =
            FindFirstObjectByType<PlayerStamina>();
    }

    private void Update()
    {
        staminaSlider.value =
            stamina.CurrentStamina /
            stamina.MaxStamina;
    }
}