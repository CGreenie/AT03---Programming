using UnityEngine;

public class InteractableExample : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Debug.Log(Random.Range(0, 10));
    }

}
