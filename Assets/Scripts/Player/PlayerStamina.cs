using UnityEngine;

public class PlayerStamina : MonoBehaviour
{
    [Header("Stamina")]
    [SerializeField] private float maxStamina = 100f;

    [SerializeField] private float drainSpeed = 20f;

    [SerializeField] private float recoverSpeed = 15f;

    [SerializeField] private float recoverDelay = 1.5f;

    private float currentStamina;

    private float recoverTimer;

    public float CurrentStamina => currentStamina;

    public float MaxStamina => maxStamina;

    private void Start()
    {
        currentStamina = maxStamina;
    }

    public bool CanSprint()
    {
        return currentStamina > 5f;
    }

    public void UseStamina()
    {
        currentStamina -= drainSpeed * Time.deltaTime;

        currentStamina =
            Mathf.Clamp(currentStamina, 0, maxStamina);

        recoverTimer = recoverDelay;
    }

    private void Update()
    {
        if (recoverTimer > 0)
        {
            recoverTimer -= Time.deltaTime;
        }
        else
        {
            RecoverStamina();
        }
    }

    private void RecoverStamina()
    {
        currentStamina += recoverSpeed * Time.deltaTime;

        currentStamina =
            Mathf.Clamp(currentStamina, 0, maxStamina);
    }
}