using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour, Goal
{

    private bool moving;
    private int direction;
    public float speed;
    public bool vertical;
    private Vector2 startPosition;
    private ParticleSystem waveParticles;
    private SpriteRenderer renderer;
    public Sprite turnedOn;
    public Sprite turnedOff;

    void Awake (){
        renderer = GetComponent<SpriteRenderer>();
        waveParticles = GetComponentInChildren<ParticleSystem>();
        waveParticles.Stop();
    }

    void Start()
    {
        startPosition = this.transform.position;
        direction = 1;
    }

    public void InputResult(bool input)
    {
        if (input)
        {
            SuccessState();
        } else
        {
            FailureState();
        }
    }

    public void SuccessState()
    {
        moving = true;
        waveParticles.Play();
        renderer.sprite = turnedOn;
        FindObjectOfType<AudioManagerController>().Play("Hover");
    }

    public void FailureState()
    {
        moving = false;
        waveParticles.Stop();
        renderer.sprite = turnedOff;
        FindObjectOfType<AudioManagerController>().Stop("Hover");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(moving)
        {
            if (!vertical)
            {
                this.transform.position = new Vector2(transform.position.x + (direction * Time.fixedDeltaTime * speed), transform.position.y);
            } else {
                this.transform.position = new Vector2(transform.position.x, transform.position.y + (direction * Time.fixedDeltaTime * speed));
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "PlatformBumper")
        {
            direction = direction * -1;
        }

        if (collision.gameObject.tag == "Player")
        {
            collision.transform.parent = transform;
        } 
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.parent = null;
        }
    }
}
