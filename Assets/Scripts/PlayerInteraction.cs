using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    public float reach = 8f;            // Interaction Distance
    public float reachPlayer = 2f;

    public Image crosshair;           // Crosshair Link
    //public Text infoPanel;            // Text UI Link
    void Start()
    {
        
    }

    void Update()
    {
        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * reach, Color.blue, 0.01f);

        Debug.DrawRay(this.transform.position, this.transform.forward * reach, Color.red, 0.01f);

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit objectHit, reach) == true)
        {
            Debug.Log($"{objectHit.collider.name} detected.");
        }
        else
        {
            Debug.Log("No object in range.");
        }

        //if (Physics.Raycast(this.transform.position, this.transform.forward, out RaycastHit objectHitPlayer, reachPlayer) == true)
        //{
        //    Debug.Log($"{objectHitPlayer.collider.name} detected.");
        //}
        //else
        //{
        //    Debug.Log("No object in range.");
        //}
    }
}
