using System.Collections.Generic;
using UnityEngine;

public class Soldier : MonoBehaviour
{
    private string soldierName;
    private string woundType;
    private List<string> treatment;
    private int countOfSupplies;

    public void Initialize(SoldierData data)
    {
        soldierName = data.name;
        woundType = data.woundType;
        treatment = new List<string>(data.treatment);
        countOfSupplies = data.countOfSupplies;

        Debug.Log($"Initialized Soldier: {soldierName}, Wound: {woundType}, Treatment: {string.Join(", ", treatment)}, Supplies Needed: {countOfSupplies}");
    }
}
