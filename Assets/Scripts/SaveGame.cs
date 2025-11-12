using System.IO;
using Unity.VisualScripting;
using UnityEngine;


/**
 * By Shane Brooker
 * Student ID:     P238614
 * Student Email:  P238614@tafe.wa.edu.au
 * Personal Email: shane.brooker17@gmail.com
**/

[System.Serializable]
public class SaveData
{
    public Vector3 position;
    public int health;
    public int experience;
    public int level;
}

public class SaveGame : MonoBehaviour
{
    public GameObject SetPlayer()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player == null )
        {
            Debug.Log("Could not find Player in scene.");
        }
        return player;
    }

    [ContextMenu("Save Player")]
    public void GetPlayerData()
    {
        GameObject player = SetPlayer();
        {
            Debug.Log("Pad touched.");
            StatsAndLeveling stats = player.GetComponent<StatsAndLeveling>();

            Vector3 playerPosition = player.transform.position;
            int playerHealth = stats.currentHealth;
            int playerExperience = stats.currentExperience;
            int playerLevel = stats.playerLevel;

            SaveDetailsToFile(playerPosition, playerHealth, playerExperience, playerLevel);
            Debug.Log("Saved to file.");
        }
    }

    void SaveDetailsToFile(Vector3 playerPosition, int playerHealth, int playerExperience, int playerLevel)
    {
        string saveFolder = Path.Combine(Application.dataPath, "Save Files");
        string fileName = Path.Combine(saveFolder, "SavedGame.json");

        if (!Directory.Exists(saveFolder))
        {
            Directory.CreateDirectory(saveFolder);
            Debug.Log($"Created save folder at: {saveFolder}");
        }

        SaveData saveData = new SaveData
        {
            position = { x = playerPosition.x, y = playerPosition.y, z = playerPosition.z },
            health = playerHealth,
            experience = playerExperience,
            level = playerLevel
        };
        // position, health, experience, level set as string in JSON format
        string jsonData = JsonUtility.ToJson(saveData, true);


        if (!File.Exists(fileName))
        {
            File.WriteAllText(fileName, jsonData);
            Debug.Log($"No save file found — created new JSON at:\n{fileName}\n{jsonData}");
        }
        else
        {
            File.WriteAllText(fileName, jsonData);
            Debug.Log($"Saved game data to: {fileName}\n{jsonData}");
        }
    }
}
