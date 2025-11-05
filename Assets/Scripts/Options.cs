using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] GameObject resolution_Dropdown;
    [SerializeField] Button Forward;
    [SerializeField] Button Left;
    [SerializeField] Button Right;
    [SerializeField] Button Back;

    public InputActionAsset inputActions;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (!PlayerPrefs.HasKey("Forward"))
        {
            PlayerPrefs.SetString("Forward", "W");
        }
        if (!PlayerPrefs.HasKey("Left"))
        {
            PlayerPrefs.SetString("Left", "A");
        }
        if (!PlayerPrefs.HasKey("Right"))
        {
            PlayerPrefs.SetString("Right", "D");
        }
        if (!PlayerPrefs.HasKey("Back"))
        {
            PlayerPrefs.SetString("Back", "S");
        }

        if (!PlayerPrefs.HasKey("resolution"))
        {
            PlayerPrefs.SetInt("resolution", 1080);
            
        }
            
        Load();
        

    }

    public void on_BacktoMenu_pressed()
    {
        Save();
        gameObject.SetActive(false);
    }


    public void ChangeResolutionDropdown(int temp_resolution)
    {
        Debug.Log(temp_resolution);
        if (temp_resolution == 0)
        {
            Screen.SetResolution(1920, 1080, FullScreenMode.FullScreenWindow);
        }
        if (temp_resolution == 1)
        {
            Screen.SetResolution(1280, 720, FullScreenMode.FullScreenWindow);
        }
        if (temp_resolution == 2)
        {
            Screen.SetResolution(3840, 2160, FullScreenMode.FullScreenWindow);
        }
    }
    public void ChangeVolume()
    {
        
        Save();
    }

    private void Load()
    {
        int temp_resolution = PlayerPrefs.GetInt("resolution");
        if (temp_resolution == 1080)
        {
            Screen.SetResolution(1920, 1080, FullScreenMode.FullScreenWindow);
        }
        if (temp_resolution == 720)
        {
            Screen.SetResolution(1280, 720, FullScreenMode.FullScreenWindow);
        }
        if (temp_resolution == 2160)
        {
            Screen.SetResolution(3840, 2160, FullScreenMode.FullScreenWindow);
        }

       //inputActions.

        
    }
    
    private void Save()
    {
        PlayerPrefs.Save();
    }
}
