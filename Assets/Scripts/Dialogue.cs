using UnityEngine;

public class Dialogue : MonoBehaviour, IInteractable
{
    //Elise Avery
    //30128123
    //this is basically a script to store strings. Yes I know I could use a Json or text file for this, but this is the quick and dirty way to do it for a prototype.
    public string dialogue;
    public string choice1;
    public string choice2;
    public string ifchoice1;
    public string ifchoice2;
     public void Interact()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<DialoguePlayer>().talk(gameObject);
    }
}
