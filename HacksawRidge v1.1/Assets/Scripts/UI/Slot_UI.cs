using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Slot_UI : MonoBehaviour
{
    public Image itemIcon; // Reference to the icon image
    public TextMeshProUGUI quantityText; // Reference to the quantity text

    public string itemName; // Add this field to store the name of the item

    public void SetSlot(string itemName, Sprite itemSprite, int count)
    {
        if (itemSprite != null)
        {
            this.itemName = itemName; // Store item name
            itemIcon.sprite = itemSprite;
            itemIcon.color = new Color(1, 1, 1, 1); // Make icon visible
            quantityText.text = count.ToString();
        }
        else
        {
            SetEmpty();
        }
    }


    public void SetItem(Inventory.Slot slot)
    {
        if (slot != null)
        {
            // Assign the item properties
            itemName = slot.type.ToString(); // Assuming `type` is an enum or similar
            itemIcon.sprite = slot.icon;
            itemIcon.color = new Color(1, 1, 1, 1); // Ensure the icon is visible
            quantityText.text = slot.count.ToString();
        }
        else
        {
            SetEmpty();
        }
    }

    public void SetEmpty()
    {
        itemName = ""; // Clear the item name
        itemIcon.sprite = null;
        itemIcon.color = new Color(1, 1, 1, 0); // Hide the icon
        quantityText.text = ""; // Clear the quantity text
    }
}
