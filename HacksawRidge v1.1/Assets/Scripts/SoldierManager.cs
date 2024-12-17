using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

public class SoldierManager : MonoBehaviour
{
    public GameObject soldierPrefab;

    private void Start()
    {
        StartCoroutine(LoadSoldierData());
    }

    private IEnumerator LoadSoldierData()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, "Files/soldierInfo.json");

        string jsonData = "";

        if (filePath.Contains("://") || filePath.Contains(":///"))
        {
            // For Android and WebGL
            UnityWebRequest request = UnityWebRequest.Get(filePath);
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
                jsonData = request.downloadHandler.text;
            else
            {
                Debug.LogError("Failed to load JSON: " + request.error);
                yield break;
            }
        }
        else
        {
            jsonData = File.ReadAllText(filePath);
        }

        SoldierDataList soldierDataList = JsonUtility.FromJson<SoldierDataList>(jsonData);

        List<SoldierData> randomizedSoldiers = new List<SoldierData>(soldierDataList.soldiers);
        List<Position> randomizedPositions = new List<Position>(soldierDataList.positions);

        System.Random rng = new System.Random();
        randomizedSoldiers.Sort((a, b) => rng.Next(-1, 2));
        randomizedPositions.Sort((a, b) => rng.Next(-1, 2));

        int count = Mathf.Min(randomizedSoldiers.Count, randomizedPositions.Count);

        for (int i = 0; i < count; i++)
        {
            Position pos = randomizedPositions[i];
            Vector3 spawnPosition = new Vector3(pos.x, pos.y, 0);

            GameObject soldier = Instantiate(soldierPrefab, spawnPosition, Quaternion.identity);
            Soldier soldierScript = soldier.GetComponent<Soldier>();

            if (soldierScript != null)
                soldierScript.Initialize(randomizedSoldiers[i]);
            else
                Debug.LogError("Soldier prefab does not have a Soldier script attached.");
        }
    }
}
