using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    public float reach = 3f;            // Interaction Distance

    //public Image crosshair;           // Crosshair Link
    //public Text infoPanel;            // Text UI Link
    void Start()
    {
        
    }

    void Update()
    {
        Debug.DrawRay(this.transform.position, this.transform.forward * reach, Color.blue, 0.01f);
    }
}
