using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * By Shane Brooker
 * Student ID:     P238614
 * Student Email:  P238614@tafe.wa.edu.au
 * Personal Email: shane.brooker17@gmail.com
**/

public class StatsAndLeveling : MonoBehaviour
{
    private bool isGameOver = false;
    public int maxHealth = 100;
    public int minHealth = 0;
    public int currentHealth = 0;

    public int maxExperience = 100;
    public static int currentExperience = 0; // Saved during lifetime of game

    public static int playerLevel = 1; // Saved during lifetime of game

    void Start()
    {
        currentHealth = maxHealth;
        Debug.Log($"Player Level: {playerLevel}");
        Debug.Log($"Player Experience: {currentExperience} / {maxExperience}");
    }

    void Update()
    {
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
        Debug.Log("Game Over triggered.");

        if (currentHealth <= minHealth)
        {
            GetComponent<PlayerController>().enabled = false;
            isGameOver = true;
            Time.timeScale = 0f; // Stops all game time
            Debug.Log("Game time stopped...");

            Debug.Log("Game Over.");
            Debug.Log("Press 'Spacebar' to respawn.");

            if (Input.GetKeyDown(KeyCode.Space) == true)
            {
                Respawn();
            }
        }
    }

    public void Respawn()
    {
        Time.timeScale = 01f;
        // GetComponent<PlayerController>().enabled = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
