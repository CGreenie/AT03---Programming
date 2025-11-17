using System.IO;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StatsAndLeveling playerData = other.GetComponent<StatsAndLeveling>();
            SavePlayerData(playerData, other.transform.position);
        }
    }

    public void SavePlayerData(StatsAndLeveling playerData, Vector3 playerTransform)
    {
        PlayerSaveData saveData = new PlayerSaveData
        {
            playerPosition = playerTransform,
            currentHealth = playerData.currentHealth,
            currentExperience = playerData.currentExperience,
            playerLevel = playerData.playerLevel,
        };

        // Saves in format: {"playerPosition{x,y,z}, "currentHealth", "currentExperience", "playerLevel"}
        string json = JsonUtility.ToJson(saveData);

        string folderPath = Path.Combine(Application.dataPath, "Save Files");
        string filePath = Path.Combine(folderPath, "PlayerSave.json");


        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        File.WriteAllText(filePath, json);
        Debug.Log($"Game saved at: {filePath}");
    }
}
