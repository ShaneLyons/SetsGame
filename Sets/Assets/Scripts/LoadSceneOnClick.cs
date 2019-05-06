using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour
{
    public string sceneName;
    void Start()
    {
    }

    // Start is called before the first frame update
    public void loadByIndex()
    {
        SceneManager.LoadScene(sceneName);
    }
}
