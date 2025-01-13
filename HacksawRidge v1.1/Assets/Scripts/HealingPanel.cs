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

    // References to the slots in the top-left section of the UI
    [SerializeField] private List<Slot_UI> healingSlots;

    [SerializeField] private List<Slot_UI> bottomLeftSlots;

    // Sprites for the items
    [SerializeField] private Sprite morphiumSprite;
    [SerializeField] private Sprite tourniquetSprite;
    [SerializeField] private Sprite toiletPaperSprite;
    [SerializeField] private Sprite safetyPinSprite;
    [SerializeField] private Sprite drugsSprite;
    [SerializeField] private Sprite bandageSprite;
    [SerializeField] private Sprite pillsSprite;
    [SerializeField] private Sprite dogTagSprite;

    private List<string> currentTreatmentOrder; // Correct treatment order from the JSON

    private int currentTreatmentIndex = 0; // Tracks the current step in the treatment sequence

    private void Start()
    {
        PopulateHealingSlots();
        PopulateBottomLeftSlots();
    }

    private void PopulateHealingSlots()
    {
        Debug.Log($"Healing Slots Count at Start: {healingSlots?.Count}");

        // Ensure there are enough slots assigned
        if (healingSlots == null || healingSlots.Count < 5)
        {
            Debug.LogError("Not enough slots assigned to the healing panel!");
            return;
        }

        // Populate the slots with items and quantity of 5
        healingSlots[0].SetSlot("Morphium", morphiumSprite, 5);
        healingSlots[1].SetSlot("Tourniquet", tourniquetSprite, 5);
        healingSlots[2].SetSlot("ToiletPaper", toiletPaperSprite, 5);
        healingSlots[3].SetSlot("SafetyPin", safetyPinSprite, 5);
        healingSlots[4].SetSlot("Drugs", drugsSprite, 5);
    }

    private void PopulateBottomLeftSlots()
    {
        Debug.Log($"Bottom Left Slots Count at Start: {bottomLeftSlots?.Count}");

        // Ensure there are enough slots assigned
        if (bottomLeftSlots == null || bottomLeftSlots.Count < 3)
        {
            Debug.LogError("Not enough slots assigned to the bottom-left inventory!");
            return;
        }

        // Populate the slots with items
        bottomLeftSlots[0].SetSlot("Bandage", bandageSprite, 2);
        bottomLeftSlots[1].SetSlot("Pills", pillsSprite, 2);
        bottomLeftSlots[2].SetSlot("DogTag", dogTagSprite, 1);
    }

    public void InitializeTreatment(string woundType, List<string> treatmentOrder)
    {
        currentTreatmentOrder = treatmentOrder;
        currentTreatmentIndex = 0;

        Debug.Log($"Treatment for {woundType}: {string.Join(", ", treatmentOrder)}");
    }

    public void CheckTreatmentOrder(int slotIndex, GameObject draggedItem)
    {
        string draggedItemName = draggedItem.GetComponent<Slot_UI>().itemName;

        if (currentTreatmentIndex < currentTreatmentOrder.Count)
        {
            string expectedItem = currentTreatmentOrder[currentTreatmentIndex];

            if (draggedItemName == expectedItem)
            {
                Debug.Log($"Correct item: {draggedItemName} for step {currentTreatmentIndex + 1}");
                currentTreatmentIndex++;

                if (currentTreatmentIndex >= currentTreatmentOrder.Count)
                {
                    Debug.Log("All treatments applied successfully!");
                }
            }
            else
            {
                Debug.LogError($"Wrong item: {draggedItemName}. Expected: {expectedItem}");
            }
        }
    }

    private void Awake()
    {
        // Initialize the dictionary with wound types and corresponding sprites
        woundSprites = new Dictionary<string, Sprite>
        {
            { "BrokenLeg", brokenLegSprite },
            { "BrokenArm", brokenArmSprite },
            { "GunshotWound", gunshotWoundSprite }
        };
        if (healingSlots == null || healingSlots.Count == 0)
        {
            Debug.LogError("Healing slots are not assigned or are empty!");
        }
        else
        {
            Debug.Log($"Healing Slots Initialized: {healingSlots.Count}");
        }

        if (bottomLeftSlots == null || bottomLeftSlots.Count == 0)
        {
            Debug.LogError("Bottom-left slots are not assigned or are empty!");
        }
        else
        {
            Debug.Log($"Bottom Left Slots Initialized: {bottomLeftSlots.Count}");
        }
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
