using UnityEngine;

public class DamageHealth : MonoBehaviour
{
    public int damage = 25;

    // Triggers on collision
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Ouch by: {damage}");

        if (other.tag == "Player")
        {
            other.GetComponent<StatsAndLeveling>().TakeDamage(damage);
        }
    }
}

