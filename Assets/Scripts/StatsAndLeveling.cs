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
    public int minHealth = 0;
    public int currentHealth = 0;

    public int maxExperience = 100;
    public int currentExperience = 0;

    public int playerLevel = 1;

    void Start()
    {
        currentHealth = maxHealth;
        // TODO: call UI health bar to update
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
            Debug.Log("Game Over.");
        }

        // TODO: Call UI health bar to update here
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
        // TODO: Call UI health bar to update here
    }

    public void AddExperience(int experience)
    {
        currentExperience += experience;

        if (currentExperience >= maxExperience)
        {
            // Carry over XP above cap to next level
            currentExperience -= maxExperience;
            LevelUp(playerLevel);
        }
        Debug.Log($"Experience: {currentExperience} / {maxExperience}");
    }

    void LevelUp(int currentLevel)
    {
        playerLevel += 1;
        Debug.Log("LEVEL UP!");
        Debug.Log($"Level: {currentLevel}");
    }
}
