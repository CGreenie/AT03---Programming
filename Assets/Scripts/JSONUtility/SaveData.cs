using System.IO;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        StatsAndLeveling playerData = other.GetComponent<StatsAndLeveling>();
        SavePlayerData(playerData, other.transform);
    }

    public void SavePlayerData(StatsAndLeveling playerData, Transform playerTransform)
    {
        PlayerSaveData saveData = new PlayerSaveData
        {
            playerPosition = playerTransform.position,
            currentHealth = playerData.currentHealth,
            currentExperience = playerData.currentExperience,
            playerLevel = playerData.playerLevel,
        };

        string json = JsonUtility.ToJson(saveData);
        Debug.Log($"Saving JSON: {json}");


        string folderPath = Path.Combine(Application.dataPath, "Save Files");
        string filePath = Path.Combine(folderPath, "PlayerSave.json");


        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        try
        {
            File.WriteAllText(filePath, json);
            Debug.Log($"Game saved at: {filePath}");
        }
        catch (System.Exception e)
        {
            Debug.Log($"Failed to save game.");
        }
    }



}
