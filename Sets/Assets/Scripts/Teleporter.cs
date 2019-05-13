using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour, Goal
{
    public Sprite teleporter_unlit; 
    public Sprite teleporter_lit;
    public GameObject lightBeam;
    public SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        lightBeam.gameObject.SetActive(false);
        spriteRenderer = GetComponent<SpriteRenderer>(); // we are accessing the SpriteRenderer that is attached to the Gameobject
        if (spriteRenderer.sprite == null) // if the sprite on spriteRenderer is null then
        {
            spriteRenderer.sprite = teleporter_unlit; // set the sprite to teleporter_unlit
        }
    }

    public void SuccessState()
    {
        spriteRenderer.sprite = teleporter_lit;
        lightBeam.gameObject.SetActive(true);
        //FindObjectOfType<AudioManagerController>().Play("DoorMoving");
    }

    public void FailureState()
    {
        spriteRenderer.sprite = teleporter_unlit;
        lightBeam.gameObject.SetActive(false);
        //FindObjectOfType<AudioManagerController>().Play("DoorMoving");
    }
    

    public void InputResult(bool isCorrect)
    {
        if (isCorrect)
        {
            SuccessState();
        }
        else
        {
            FailureState();
        }
    }
}
