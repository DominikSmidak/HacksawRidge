using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        DraggableItem draggableItem = eventData.pointerDrag.GetComponent<DraggableItem>();

        if (draggableItem != null)
        {
            // Snap the dragged item to this slot
            draggableItem.transform.SetParent(transform);
            draggableItem.transform.position = transform.position;

            Debug.Log($"Item dropped into slot: {gameObject.name}");
        }
    }
}
