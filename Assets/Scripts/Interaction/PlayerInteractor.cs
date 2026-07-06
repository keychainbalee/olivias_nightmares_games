using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteractor : MonoBehaviour
{
    [Header("Detection")]
    [SerializeField] private Transform detectionPoint;
    [SerializeField] private float detectionRadius = 2f;
    [SerializeField] private LayerMask interactLayer;

    [Header("UI")]
    [SerializeField] private Button interactButton;
    [SerializeField] private TMP_Text interactText;

    private IInteractable currentInteractable;

    private void Start()
    {
        interactButton.gameObject.SetActive(false);

    }

    private void Update()
    {
        DetectInteractable();
    }

    private void DetectInteractable()
    {
        currentInteractable = null;

        Collider[] hits = Physics.OverlapSphere(
            detectionPoint.position,
            detectionRadius,
            interactLayer
        );

        foreach (Collider hit in hits)
        {

            IInteractable interactable =
                hit.GetComponentInParent<IInteractable>();


            if (interactable != null)
            {
                currentInteractable = interactable;

                interactButton.gameObject.SetActive(true);
                interactText.text = GetInteractionText(hit);

                return;
            }
        }

        interactButton.gameObject.SetActive(false);
    }

    public void Interact()
    {
        Debug.Log("Button ditekan");

        if (currentInteractable == null)
        {
            Debug.Log("currentInteractable NULL");
            return;
        }

        Debug.Log("Interact dengan : " + currentInteractable.GetType().Name);

        currentInteractable.Interact();
    }

    private string GetInteractionText(Collider hit)
    {
        switch (hit.tag)
        {
            case "Flashlight":
                return "Ambil Senter";

            case "Key":
                return "Ambil Kunci";

            case "Door":
                return "Buka Pintu";

            default:
                return "Interaksi";
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (detectionPoint == null)
            return;

        Gizmos.color = Color.green;

        Gizmos.DrawWireSphere(
            detectionPoint.position,
            detectionRadius
        );
    }
}