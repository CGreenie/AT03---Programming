using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using JSONUtility;
using System.Threading.Tasks;

/**
 * By Shane Brooker
 * Student ID:     P238614
 * Student Email:  P238614@tafe.wa.edu.au
 * Personal Email: shane.brooker17@gmail.com
**/

[System.Serializable]
public class PlayerSaveData
{
    public Vector3 playerPosition;
    public int currentHealth;
    public int currentExperience;
    public int playerLevel;
}

public class StatsAndLeveling : MonoBehaviour
{
    // Reference LoadData.cs & SaveData.cs for respawn function
    private LoadData loadScript;
    private SaveData saveScript;

    // Assign audio in Inspector
    public AudioClip playerRespawn;
    private AudioSource audioRespawn;

    // Respawn flags
    private bool isGameOver = false;
    private Vector3 spawnPosition;

    // Player Stats
    public Vector3 playerPosition;
    private int maxHealth = 100;
    public int minHealth = 0;
    public int currentHealth = 0;
    public int maxExperience = 100;
    public int currentExperience = 0;
    public int playerLevel = 1;

    void Start()
    {
        // Instantiate other scripts; set spawn point for Game Over condition
        saveScript = FindAnyObjectByType<SaveData>();
        loadScript = GetComponent<LoadData>();
        audioRespawn = GetComponent<AudioSource>();
        spawnPosition = transform.position;

        if (loadScript == null)
        {
            Debug.Log("LoadData script not found in scene.");
        }
        currentHealth = maxHealth;
        Debug.Log($"Player Level: {playerLevel}");
        Debug.Log($"Player Experience: {currentExperience} / {maxExperience}");
    }

    void Update()
    {
        // Resumes game time on KeyDown when Game Over is triggered
        if (isGameOver == true && Input.GetKeyDown(KeyCode.Space) == true)
        {
            Respawn();
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // check if health is less than minHealth
        if (currentHealth < minHealth)
        {
            currentHealth = minHealth;
        }

        Debug.Log($"Health: {currentHealth}");

        if (currentHealth <= 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        if (currentHealth <= minHealth)
        {
            Debug.Log("Game Over.");
            Debug.Log("Press 'Spacebar' to respawn.");

            // auto-save to keep progress on death
            saveScript.SavePlayerData(this, spawnPosition);
            
            isGameOver = true;

            // Stops all movement and inputs; Only resumes when SpaceBar is pressed, see Update()
            Time.timeScale = 0f;
        }
    }

    public void Respawn()
    {
        // Player can only be moved when CharacterController is disabled
        GetComponent<CharacterController>().enabled = false;
        Time.timeScale = 01f; // Resumes all game time
        loadScript.LoadPlayerData(this, spawnPosition, this.gameObject); // Loads auto-saved stats; moves Player to spawn point
        GetComponent<CharacterController>().enabled = true;

        audioRespawn.PlayOneShot(playerRespawn);
        isGameOver = false;
        currentHealth = maxHealth;
        Debug.Log($"Player Level: {playerLevel}");
        Debug.Log($"Player Experience: {currentExperience} / {maxExperience}");
        Debug.Log($"Player Health: {currentHealth}");
    }

    public void Heal(int heal)
    {
        // add heal variable to currentHealth
        currentHealth += heal;

        // check if health is more than maxHealth
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        Debug.Log($"Player Health: {currentHealth}");
    }

    public void AddExperience(int experience)
    {
        currentExperience += experience;
        saveScript.SavePlayerData(this, transform.position);
        Debug.Log($"Experience: {currentExperience} / {maxExperience}");

        if (currentExperience >= maxExperience)
        {
            playerLevel = LevelUp(playerLevel);
        }
    }

    int LevelUp(int currentLevel)
    {
        currentLevel += 1;
        Debug.Log("LEVEL UP!");
        Debug.Log($"Level: {currentLevel}");

        // Carry over XP above cap to next level
        currentExperience -= maxExperience;
        Debug.Log($"Experience: {currentExperience} / {maxExperience}");
        return currentLevel;
    }
}
