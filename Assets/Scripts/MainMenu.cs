using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Elise Avery
    //30128123
    //grab the options panel to show or hide it. 
    public GameObject options_panel;
    // This script basically just lets you press buttons in the main menu.
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void on_newgame_pressed()
    {
        SceneManager.LoadScene("Test Scene");
    }

    public void on_loadgame_pressed()
    {
        Debug.Log("Loading saves isn't implemented, so this just opens the main scene. Fix this later!");
        SceneManager.LoadScene("Test Scene");
    }

    public void on_options_pressed()
    {
        options_panel.SetActive(true);
    }

    public void on_quit_pressed()
    {
        Application.Quit();

    }
}
