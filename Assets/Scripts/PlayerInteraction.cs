using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


interface IInteractable
{
    public void Interact();
}

public class PlayerInteraction : MonoBehaviour
{
    public float reach = 8f;            // Interaction Distance

    public Image crosshair;           // Crosshair Link
    //public Text infoPanel;            // Text UI Link

    public UIManager UIManager;

    void Start()
    {
        
    }

    void Update()
    {
        // For debug
        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * reach, Color.blue, 0.01f);

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit objectHit, reach) == true)
        {
            Debug.Log($"{objectHit.collider.name} detected.");

            if (objectHit.collider.TryGetComponent(out IInteractable interactableObject))
            {
                UIManager.InteractPanelOn();
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                interactableObject.Interact();
            }

        }
        else
        {
            Debug.Log("No object in range.");
            UIManager.InteractPanelOff();
        }

        

        
    }
}
