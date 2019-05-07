using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectController : MonoBehaviour
{
    public Button button1, button2, button3;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("level select controller inited");
        button1.onClick.AddListener(loadLevel);
        Debug.Log(button1);
        //button2.onClick.AddListener(credits);
        //button3.onClick.AddListener(clicked);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void loadLevel()
    {
        Debug.Log("loadLevel");
        SceneManager.LoadScene("Level 1 Tutorial");
    }
}
