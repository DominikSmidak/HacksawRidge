using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        DraggableItem draggableItem = eventData.pointerDrag.GetComponent<DraggableItem>();

        if (draggableItem != null)
        {
            Debug.Log($"Dropped item: {eventData.pointerDrag.name} into slot: {gameObject.name}");

            // Snap the dragged item to this slot
            draggableItem.transform.SetParent(transform);
            draggableItem.transform.position = transform.position;
        }
        else
        {
            Debug.LogError("No draggable item detected on drop!");
        }
    }
}
