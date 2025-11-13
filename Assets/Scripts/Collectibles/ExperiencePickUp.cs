using UnityEngine;

public class ExperiencePickUp : MonoBehaviour
{
    public int experiencePoints = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (experiencePoints == 0)
        {
            Debug.Log("Experience points for this object need to be set!");
        }
        
        if (other.tag == "Player")
        {
            other.GetComponent<StatsAndLeveling>().AddExperience(experiencePoints);
        }
    }

}