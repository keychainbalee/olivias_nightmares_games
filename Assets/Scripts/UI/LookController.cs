using UnityEngine;
using UnityEngine.EventSystems;

public class LookController : MonoBehaviour,
    IPointerDownHandler,
    IDragHandler,
    IPointerUpHandler
{
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private float sensitivity = 0.2f;

    private Vector2 lastPosition;
    private bool isDragging;

    public void OnPointerDown(PointerEventData eventData)
    {
        lastPosition = eventData.position;
        isDragging = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!isDragging) return;

        Vector2 delta = eventData.position - lastPosition;

        playerMovement.SetLookInput(delta * sensitivity);

        lastPosition = eventData.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDragging = false;
        playerMovement.SetLookInput(Vector2.zero);
    }
}