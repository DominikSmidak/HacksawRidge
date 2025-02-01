using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


[System.Serializable]
public class HealingData
{
    public int countOfSupplies;
    public List<string> treatment;
}

public class HealingSystem : MonoBehaviour
{
    public Transform slotContainer;
    public Transform itemContainer;
    public Canvas healingCanvas;

    public GameObject slotLeftPanel;
    public int slotCount;
    public GameObject[] itemPrefabs2;

    private List<Slot> spawnedSlots = new List<Slot>();
    private Soldier soldier;
    private List<string> treatment;
    private int countOfSupplies;

    public SoldierArea soldierArea;
    public SoldierInteraction closeHealing;

    void Start()
    {
        soldier = GetComponentInParent<Soldier>();

        if (soldier == null)
        {
            Debug.LogError("HealingSystem could not find a Soldier component in its parent.");
            return;
        }

        treatment = soldier.GetTreatment();
        countOfSupplies = soldier.GetCountOfSupplies();

        GenerateItems();
    }

    void GenerateItems()
    {
        for (int i = 0; i < slotCount; i++)
        {
            Slot slot = Instantiate(slotLeftPanel, itemContainer.transform).GetComponent<Slot>();
            if (i < itemPrefabs2.Length)
            {
                GameObject item = Instantiate(itemPrefabs2[i], slot.transform);
                item.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
                slot.currentItem = item;
            }
        }

        for (int i = 0; i < countOfSupplies; i++)
        {
            Slot slot = Instantiate(slotLeftPanel, slotContainer.transform).GetComponent<Slot>();
            slot.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
            slot.healingSystem = this;

            string correctItemName = treatment[i];
            slot.correctItemName = correctItemName;
            spawnedSlots.Add(slot);
        }
    }

    public void CheckCompletion()
    {
        bool allCorrect = true;
        foreach (var slot in spawnedSlots)
        {
            if (!slot.IsCorrect())
            {
                allCorrect = false;
                break;
            }
        }

        if (allCorrect)
        {
            //healingCanvas.gameObject.SetActive(false);
            closeHealing.CloseHealing();
        }
    }
    public bool IsCorrectSlot(Slot slot, string itemName)
    {
        return slot.correctItemName == itemName;
    }

}

