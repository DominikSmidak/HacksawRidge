using System.Collections.Generic;
using UnityEngine;

public class Soldier : MonoBehaviour
{
    private string soldierName;
    private string woundType;
    private List<string> treatment;
    private int countOfSupplies;

    private SpriteRenderer spriteRenderer;
    private Timer timer;
    private SoldierArea soldierArea;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>() ?? gameObject.AddComponent<SpriteRenderer>();
        timer = GetComponent<Timer>() ?? gameObject.AddComponent<Timer>();

        soldierArea = GetComponentInChildren<SoldierArea>();
        if (soldierArea == null)
            Debug.LogError("SoldierArea script is missing as a child of Soldier prefab.");
    }
    public string GetWoundType()
    {
        return woundType;
    }

    public Sprite GetSprite()
    {
        return spriteRenderer.sprite;
    }

    public List<string> GetTreatment()
    {
        return treatment;
    }

    public int GetCountOfSupplies()
    {
        return countOfSupplies;
    }

    public void Initialize(SoldierData data)
    {
        soldierName = data.name;
        woundType = data.woundType;
        treatment = new List<string>(data.treatment);
        countOfSupplies = data.countOfSupplies;

        Debug.Log($"Initialized Soldier: {soldierName}, Wound: {woundType}, Treatment: {string.Join(", ", treatment)}, Supplies Needed: {countOfSupplies}");
        
        if (!string.IsNullOrEmpty(data.spritePath))
        {
            Sprite soldierSprite = Resources.Load<Sprite>(data.spritePath);
            if (soldierSprite != null)
            {
                spriteRenderer.sprite = soldierSprite;
            }
            else
            {
                Debug.LogError($"Sprite not found at path: {data.spritePath}");
            }
        }
        SoldierArea soldierArea = GetComponentInChildren<SoldierArea>();
        if (soldierArea != null)
        {
            soldierArea.SetTimerDuration(data.time);
        }
        else
        {
            Debug.LogError("SoldierArea script not found in soldier prefab.");
        }
    }
}
