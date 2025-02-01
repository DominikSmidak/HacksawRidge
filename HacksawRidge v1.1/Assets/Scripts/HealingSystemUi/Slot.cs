using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public GameObject currentItem;
    public string correctItemName; // Name of the item that should be placed in this slot
    public HealingSystem healingSystem; // Reference to HealingSystem for validation

    // Method to check if the item in the slot is correct
    public bool IsCorrect()
    {
        if (currentItem == null)
            return false;

        DraggableItem item = currentItem.GetComponent<DraggableItem>();
        return item != null && item.itemName == correctItemName;
    }
}
