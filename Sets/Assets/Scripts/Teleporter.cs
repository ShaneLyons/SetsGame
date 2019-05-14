using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporter : MonoBehaviour, Goal
{
    public Sprite teleporter_unlit; 
    public Sprite teleporter_lit;
    public GameObject lightBeam;
    public SpriteRenderer spriteRenderer;
    public string sceneName;
    public GameObject player;
    private ParticleSystem waveParticles;
    private bool on;
    // Start is called before the first frame update
    void Start()
    {
        waveParticles = GetComponentInChildren<ParticleSystem>();
        waveParticles.Stop();
        lightBeam.gameObject.SetActive(false);
        on = false;
        spriteRenderer = GetComponent<SpriteRenderer>(); // we are accessing the SpriteRenderer that is attached to the Gameobject
        if (spriteRenderer.sprite == null) // if the sprite on spriteRenderer is null then
        {
            spriteRenderer.sprite = teleporter_unlit; // set the sprite to teleporter_unlit
        }
    }

    void Update()
    {
        
        if (transform.position.x < player.transform.position.x && on)
        {
            loadByIndex();
        }
    }

    public void SuccessState()
    {
        spriteRenderer.sprite = teleporter_lit;
        lightBeam.gameObject.SetActive(true);
        waveParticles.Play();
        //FindObjectOfType<AudioManagerController>().Play("DoorMoving");
    }

    public void loadByIndex()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void FailureState()
    {
        spriteRenderer.sprite = teleporter_unlit;
        lightBeam.gameObject.SetActive(false);
        waveParticles.Stop();
        //FindObjectOfType<AudioManagerController>().Play("DoorMoving");
    }
    

    public void InputResult(bool isCorrect)
    {
        if (isCorrect)
        {
            on = true;
            SuccessState();
        }
        else
        {
            on = false;
            FailureState();
        }
    }
}
