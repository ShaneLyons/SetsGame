using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneWhenPass : MonoBehaviour
{
    public int sceneIndex;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < player.transform.position.x)
        {
            loadByIndex();
        }
    }

    public void loadByIndex()
    {
        SceneManager.LoadScene(sceneIndex);
    }

}
