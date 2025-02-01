using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class WoundImage
{
    public string woundType;
    public Sprite woundSprite;
}

public class WoundDisplay : MonoBehaviour
{
    public Image woundImageUI;
    public TextMeshProUGUI woundTextUI;
    public WoundImage[] woundImages;

    private Soldier soldier;

    void Start()
    {
        soldier = GetComponentInParent<Soldier>();

        if (soldier == null)
        {
            Debug.LogError("WoundDisplay could not find a Soldier component in its parent.");
            return;
        }

        UpdateWoundUI();
    }

    void UpdateWoundUI()
    {
        if (woundTextUI != null)
        {
            woundTextUI.text = soldier.GetWoundType();
        }

        if (woundImageUI != null)
        {
            woundImageUI.sprite = GetWoundSprite(soldier.GetWoundType());
        }
    }

    private Sprite GetWoundSprite(string woundType)
    {
        foreach (WoundImage wi in woundImages)
        {
            if (wi.woundType == woundType)
            {
                return wi.woundSprite;
            }
        }

        Debug.LogWarning("No matching wound image found for type: " + woundType);
        return null;
    }
}


