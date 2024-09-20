using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEditor.UI;

public class ButtonPressed : MonoBehaviour
{
    public GameObject settings;
    public GameObject ReadMePanel;
    // Start is called before the first frame update
    void Start()
    {
        settings.SetActive(false);
        ReadMePanel.SetActive(false);
    }
    public void LoadScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void ToggleSettings()
    {
        if (settings.activeSelf == false)
        {
            settings.SetActive(true);
        }
        else if (settings.activeSelf == true)
        {
            settings.SetActive(false );
        }
    }

    public void ReadMe()
    {
        if (ReadMePanel.activeSelf == false)
        {
            ReadMePanel.SetActive(true);
        }
        else if (ReadMePanel.activeSelf == true)
        {
            ReadMePanel.SetActive(false);
        }
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
