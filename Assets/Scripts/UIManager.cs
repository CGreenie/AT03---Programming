using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image interactPanel;

    public void InteractPanelOn()
    {
        if (interactPanel.IsActive() != true)
        {
            interactPanel.gameObject.SetActive(true);
        }
    }

    public void InteractPanelOff()
    {
        if (interactPanel.IsActive() != false)
        {
            interactPanel.gameObject.SetActive(false);
        }
    }
}
