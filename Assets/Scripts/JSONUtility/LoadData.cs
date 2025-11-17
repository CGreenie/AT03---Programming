using System.IO;
using UnityEngine;

namespace JSONUtility
{
    public class LoadData : MonoBehaviour
    {
        private StatsAndLeveling playerData;

        private void Start()
        {
            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
            playerData = GetComponent<StatsAndLeveling>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                StatsAndLeveling playerData = other.GetComponent<StatsAndLeveling>();
                Debug.Log("Loading Save...");
                LoadPlayerData(playerData, playerData.playerPosition, other.gameObject);
                Debug.Log($"Player Level: {playerData.playerLevel}");
                Debug.Log($"Player Experience: {playerData.currentExperience} / {playerData.maxExperience}");
            }
        }

        public void LoadPlayerData(StatsAndLeveling playerData, Vector3 playerTransform, GameObject? playerObject)
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
            CharacterController cc = playerObject.GetComponent<CharacterController>();
            if (cc != null)
            {
                cc.enabled = false;
            }

            playerObject.transform.position = saveData.playerPosition;

            if (cc != null)
            {
                cc.enabled = true;
            }
        }
    }
}