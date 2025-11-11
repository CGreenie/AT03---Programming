using TMPro;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.UIElements;

public class DialoguePlayer : MonoBehaviour
{
    //Elise Avery
    //30128123

    //Brute force way of interacting with the dialogue box, just get references to lots of parts of it instead of getcomponent, since it should always be there.
    //would probably want to combine this into the playerprefab if I was doing more with this project
    //Also storing long conversations this way is bad - would actually just use yarn spinner tbh, so mocked up something simple
    public GameObject dialogueBox;
    public TextMeshProUGUI textbox;
    //below is a temp reference, replace with raycast object.trygetcomponent or whatever
    public GameObject sphere;
    
    public GameObject cameracontroller;
    public TextMeshProUGUI leftButtontext;
    public TextMeshProUGUI rightButtontext;

    public GameObject rightButton;
    public GameObject leftButton;
    public GameObject continueButton;
    //This is the current dialogue, used to store who we are currently talking to. Probably not necessary but easy and allows for different buttons to call the same thing.
    Dialogue current;


    void Start()
    {
        //initialize the textbox from the dialoguebox - not really necessary but eh
        textbox = dialogueBox.GetComponentInChildren<TextMeshProUGUI>();



    }

    // Update is called once per frame
    //currently have a button press as a debug. Will change this later.
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) && dialogueBox.activeInHierarchy == false)
        {

            displayDialogue(sphere.GetComponent<Dialogue>());


        }
    }
    /// <summary>
    /// When dialogue starts, we get the Dialogue script from the other object.
    /// We then make sure the correct buttons are visible (in case we did dialogue previously)
    /// set current to the dialogue script from the other object
    /// disable the player from moving or turning the camera
    /// change the dialogue box to the opening dialogue of the conversation, and set the left and right choice buttons to their respective text
    /// then show the dialogue box
    /// All dialogue is written in the Dialogue script attached to any object.
    /// </summary>
    /// <param name="words"></param>
    public void displayDialogue(Dialogue words)
    {
        continueButton.SetActive(false);
        rightButton.SetActive(true);
        leftButton.SetActive(true);
        current = words;
        gameObject.GetComponent<PlayerController>().enabled = false;
        cameracontroller.GetComponent<CameraController>().enabled = false;
        textbox.SetText(words.dialogue);
        leftButtontext.SetText(words.choice1);
        rightButtontext.SetText(words.choice2);
        dialogueBox.SetActive(true);
    }

    //If these buttons are pressed, we turn off the choice buttons and show the next piece of dialogue, plus a continue button to quit the dialogue.

    public void onRightButtonPressed()
    {

        rightButton.SetActive(false);
        leftButton.SetActive(false);
        textbox.SetText(current.ifchoice2);
        continueButton.SetActive(true);
    }
    public void onLeftButtonPressed()
    {

        rightButton.SetActive(false);
        leftButton.SetActive(false);
        textbox.SetText(current.ifchoice1);
        continueButton.SetActive(true);
    }

    /// <summary>
    /// If this is pressed, hide the dialogue box and let the player move again.
    /// </summary>
    public void onContinueButtonPressed()
    {
        dialogueBox.SetActive(false);
        gameObject.GetComponent<PlayerController>().enabled = true;
        cameracontroller.GetComponent<CameraController>().enabled = true;
    }

}
