using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject options_panel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
