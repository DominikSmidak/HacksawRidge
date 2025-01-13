using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Vector3 originalPosition;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Drag Started");
        originalPosition = rectTransform.position;
        canvasGroup.blocksRaycasts = false; // Allow the item to pass through drop zones
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Dragging...");
        rectTransform.position = Input.mousePosition; // Move the item with the mouse
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("Drag Ended");
        canvasGroup.blocksRaycasts = true; // Make the item raycastable again

        // Return to original position if not dropped in a valid slot
        if (transform.parent == null)
        {
            rectTransform.position = originalPosition;
        }
    }
}
