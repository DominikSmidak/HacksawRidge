using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HealingPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI woundText; // Text field to display wound type
    [SerializeField] private Image woundImage;         // Image field to display wound icon

    // Dictionary to map wound types to sprites
    private Dictionary<string, Sprite> woundSprites;

    // Sprites for each wound type
    [SerializeField] private Sprite brokenLegSprite;
    [SerializeField] private Sprite brokenArmSprite;
    [SerializeField] private Sprite gunshotWoundSprite;

    private void Awake()
    {
        // Initialize the dictionary with wound types and corresponding sprites
        woundSprites = new Dictionary<string, Sprite>
        {
            { "BrokenLeg", brokenLegSprite },
            { "BrokenArm", brokenArmSprite },
            { "GunshotWound", gunshotWoundSprite }
        };
    }

    public void UpdatePanel(string woundType)
    {
        Debug.Log($"Updating panel for woundType: {woundType}");

        // Update the text to reflect the wound type
        if (woundText != null)
        {
            woundText.text = $"Injury: {woundType}";
        }
        else
        {
            Debug.LogWarning("Wound Text is not assigned in the Inspector.");
        }

        // Try to find the sprite for the wound type
        if (woundSprites.TryGetValue(woundType, out Sprite selectedSprite))
        {
            Debug.Log($"Found sprite for wound type: {woundType}");
            woundImage.sprite = selectedSprite; // Set the sprite
        }
        else
        {
            // Log a warning if no match is found
            Debug.LogWarning($"No sprite found for wound type: {woundType}. Please check JSON or dictionary setup.");
            woundImage.sprite = null; // Clear or assign a default sprite
        }
    }
}
