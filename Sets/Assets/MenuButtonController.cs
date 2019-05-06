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
        button1.onClick.AddListener(clicked);
        button2.onClick.AddListener(clicked);
        button3.onClick.AddListener(clicked);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void clicked()
    {
        Debug.Log("clicked");
        SceneManager.LoadScene(0);
    }
}
