using System.IO;
using UnityEngine;

public class LoadData : MonoBehaviour
{
    private StatsAndLeveling playerData;

    private void Start()
    {
        playerData = GetComponent<StatsAndLeveling>();
    }

    private void OnTriggerEnter(Collider other)
    {
        StatsAndLeveling playerData = other.GetComponent<StatsAndLeveling>();
        LoadPlayerData(playerData, other.transform);
    }

    public void LoadPlayerData(StatsAndLeveling playerData, Transform playerTransform)
    {
        if (playerData == null)
        {
            Debug.Log("StatsAndLeveling script not on Player");
            return;
        }


        string folderPath = Path.Combine(Application.dataPath, "Save Files");
        string filePath = Path.Combine(folderPath, "PlayerSave.json");


        if (!File.Exists(filePath))
        {
            Debug.Log("No save file found");
            return;
        }

        string json = File.ReadAllText(filePath);

        PlayerSaveData saveData = JsonUtility.FromJson<PlayerSaveData>(json);

        playerData.playerPosition = saveData.playerPosition;
        playerData.currentHealth = saveData.currentHealth;
        playerData.currentExperience = saveData.currentExperience;
        playerData.playerLevel = saveData.playerLevel;

        // Move player to saved position
        CharacterController cc = playerTransform.GetComponent<CharacterController>();
        if (cc != null)
        {
            cc.enabled = false;
            playerTransform.position = saveData.playerPosition;
            cc.enabled = true;
        }
    }
}
