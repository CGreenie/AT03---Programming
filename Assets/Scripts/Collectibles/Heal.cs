using UnityEngine;

public class Heal : MonoBehaviour
{
    public int healing;

    private void OnTriggerEnter(Collider other)
    {
        // if the object that collides with this has the player tag, call Heal function

        if (other.tag == "Player")
        {
            other.GetComponent<StatsAndLeveling>().Heal(healing);

            //heal is used, deactivates health pack
            gameObject.SetActive(false);

            ////Removes from game heirarchy 
            //Destroy(gameObject, 1.5f);
        }
    }
}