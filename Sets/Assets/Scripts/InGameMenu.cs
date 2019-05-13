using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameMenu : MonoBehaviour
{
    public Button menuButton;
    public GameObject panel;
    public Button screen;
    public bool active;
    // Start is called before the first frame update
    void Start()
    {
        active = false;
        menuButton.onClick.AddListener(ToggleMenu);
        screen.onClick.AddListener(HideMenu);
    }

    void HideMenu()
    {
        active = false;
        panel.gameObject.SetActive(false);
        
    } 

    void ToggleMenu()
    {
        active = !active;
        if (active)
        {
            panel.gameObject.SetActive(true);
        }
        else
        {
            panel.gameObject.SetActive(false);
        }
    }
}
