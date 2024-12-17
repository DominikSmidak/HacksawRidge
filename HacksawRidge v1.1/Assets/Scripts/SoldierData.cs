using UnityEngine;

[System.Serializable]
public class SoldierData
{
    public string name;
    public string woundType;
    public string[] treatment;
    public int countOfSupplies;
    public string spritePath;
    public float time;
}

[System.Serializable]
public class Position
{
    public float x;
    public float y;
}

[System.Serializable]
public class SoldierDataList
{
    public SoldierData[] soldiers;
    public Position[] positions;
}

