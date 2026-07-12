using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class ExhaustedEffect : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private PlayerStamina stamina;

    private CanvasGroup canvasGroup;

    [Header("Threshold")]
    [SerializeField] private float showThreshold = 0.30f;

    [SerializeField] private float hideThreshold = 0.40f;

    [Header("Blink")]
    [SerializeField] private float minBlinkSpeed = 2f;

    [SerializeField] private float maxBlinkSpeed = 8f;

    [Header("Overlay")]
    [SerializeField] private float maxAlpha = 0.5f;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0f;
    }

    private void Update()
    {
        if (stamina == null)
            return;

        float percent = stamina.StaminaPercent;

        // Jika stamina sudah pulih
        if (percent >= hideThreshold)
        {
            canvasGroup.alpha = Mathf.MoveTowards(
                canvasGroup.alpha,
                0f,
                Time.deltaTime * 2f);

            return;
        }

        // Belum mencapai batas merah
        if (percent > showThreshold)
            return;

        // 30% -> 0%
        float t = Mathf.InverseLerp(
            showThreshold,
            0f,
            percent);

        float blinkSpeed = Mathf.Lerp(
            minBlinkSpeed,
            maxBlinkSpeed,
            t);

        float alpha =
            (Mathf.Sin(Time.time * blinkSpeed) + 1f) * 0.5f;

        canvasGroup.alpha = alpha * maxAlpha;
    }
}