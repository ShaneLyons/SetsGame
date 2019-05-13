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

    // Start is called before the first frame update
    void Start()
    {
        startPosition = this.transform.position;
        direction = 1;
    }

    public void InputResult(bool input){
        if(input){
            SuccessState();
        } else {
            FailureState();
        }
    }

    public void SuccessState(){
        moving = true;
    }

    public void FailureState(){
        moving = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(moving){
            if (!vertical)
            {
                this.transform.position = new Vector2(transform.position.x + (direction * Time.deltaTime * speed), transform.position.y);
            } else {
                this.transform.position = new Vector2(transform.position.x, transform.position.y + (direction * Time.deltaTime * speed));
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision){
        Debug.Log("collision");
        if(collision.gameObject.tag == "PlatformBumper"){
            direction = direction * -1;
        }
    }
}
