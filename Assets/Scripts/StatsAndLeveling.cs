using UnityEngine;

/**
 * By Shane Brooker
 * Student ID:     P238614
 * Student Email:  P238614@tafe.wa.edu.au
 * Personal Email: shane.brooker17@gmail.com
**/

public class StatsAndLeveling : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth = 0;

    public int maxExperience = 100;
    public int currentExperience = 0;

    public int playerLevel = 1;

    // Testing variables
    [Header("Testing Variables")]
    public int damage = 0;
    public int experience = 0;

    void Start()
    {
        currentHealth = maxHealth;
        // TODO: call UI health bar to update
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log($"Health: {currentHealth}");

        if (currentHealth <= 0)
        {
            Debug.Log("Game Over.");
        }
        // TODO: Call UI health bar to update here
    }

    void AddExperience(int experience)
    {
        currentExperience += experience;

        if (currentExperience > maxExperience)
        {
            // Carry over XP above cap to next level
            currentExperience -= maxExperience;
            LevelUp(playerLevel);
        }
    }

    void LevelUp(int currentLevel)
    {
        playerLevel += 1;
    }

    // Testing Functions
    [ContextMenu("Test TakeDamage")]
    void TestDamage()
    {
        TakeDamage(damage);
        Debug.Log($"Player Health: {currentHealth}");
    }

    [ContextMenu("Test AddExperience")]
    void TestExperience()
    {
        AddExperience(experience);
        Debug.Log($"Player Experience: {currentExperience}");
        Debug.Log($"Player Level:      {playerLevel}");
    }
}
