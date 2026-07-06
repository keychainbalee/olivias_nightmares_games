using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickController : MonoBehaviour,
    IPointerDownHandler,
    IDragHandler,
    IPointerUpHandler
{
    [SerializeField] private RectTransform background;
    [SerializeField] private RectTransform handle;
    [SerializeField] private float radius = 80f;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private float deadZone = 0.15f;
    private void Update()
    {
        playerMovement.SetMoveInput(Direction);
    }

    public Vector2 Direction { get; private set; }

    public float Magnitude => Direction.magnitude;

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 localPoint;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            background,
            eventData.position,
            eventData.pressEventCamera,
            out localPoint);

        localPoint = Vector2.ClampMagnitude(localPoint, radius);

        handle.anchoredPosition = localPoint;

        Direction = localPoint / radius;

        if (Direction.magnitude < deadZone)
        {
            Direction = Vector2.zero;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Direction = Vector2.zero;
        handle.anchoredPosition = Vector2.zero;
    }
}