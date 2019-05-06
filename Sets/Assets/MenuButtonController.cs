using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuButtonController : MonoBehaviour
{
    public Button button1, button2, button3;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("menu controller inited");
        button1.onClick.AddListener(playGame);
        button2.onClick.AddListener(credits);
        //button3.onClick.AddListener(clicked);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void playGame()
    {
        Debug.Log("playGame");
        SceneManager.LoadScene("Level 1 Tutorial");
    }

    void credits()
    {
        Debug.Log("credits");
        SceneManager.LoadScene("Credits");
    }
}
