using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour
{
    public int sceneIndex;
    void Start()
    {
    }

    // Start is called before the first frame update
    public void loadByIndex()
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
