using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] TMP_Dropdown resolution_Dropdown;
   

    public InputActionAsset inputActions;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (!PlayerPrefs.HasKey("resolution"))
        {
            PlayerPrefs.SetInt("resolution", 0);
            
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
        Save(temp_resolution);
    }
    public void ChangeVolume()
    {
        
        Save();
    }

    private void Load()
    {
        int temp_resolution = PlayerPrefs.GetInt("resolution");
        if (temp_resolution == 0)
        {
            Screen.SetResolution(1920, 1080, FullScreenMode.FullScreenWindow);
            resolution_Dropdown.value = 0;
        }
        if (temp_resolution == 1)
        {
            Screen.SetResolution(1280, 720, FullScreenMode.FullScreenWindow);
            resolution_Dropdown.value = 1;
        }
        if (temp_resolution == 2)
        {
            Screen.SetResolution(3840, 2160, FullScreenMode.FullScreenWindow);
            resolution_Dropdown.value = 2;
        }

       

        
    }
    
    private void Save(int resolution = 0)
    {
        PlayerPrefs.SetInt("resolution", resolution);
        PlayerPrefs.Save();
    }
}
