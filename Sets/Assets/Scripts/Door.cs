using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, Goal {

    private Vector3 goalPosition;
    private Vector3 startPosition;

    private bool open;
    private bool moving;

    public float openSpeed;

    void Start()
    {
        startPosition = transform.position;
        goalPosition = startPosition + new Vector3(0, 2, 0);
        open = false;
        moving = false;
    }

    public void SuccessState() {
        if (open)
        {
            moving = false;
            open = true;
        }
        else
        {
            moving = true;
            open = true;
            FindObjectOfType<AudioManagerController>().Play("DoorMoving");
        }
    }

    public void FailureState()
    {
        if(open){
            moving = true;
            open = false;
            FindObjectOfType<AudioManagerController>().Play("DoorMoving");
        } else {
            moving = false;
            open = false;
        }
    }

    void FixedUpdate()
    {
        if (moving)
        {
            float yOffset = open ? goalPosition.y - transform.position.y : transform.position.y - startPosition.y;
            if (yOffset < 0.1)
            {
                moving = false;
                FindObjectOfType<AudioManagerController>().Stop("DoorMoving");
                FindObjectOfType<AudioManagerController>().Play("DoorSlam");
            }
            transform.position += open ? new Vector3(0,openSpeed*0.1f,0) : new Vector3(0,-openSpeed*0.1f,0);
        }
    }

    public void InputResult(bool isCorrect)
    {
        if(isCorrect){
            SuccessState();
        } else {
            FailureState();
        }
    }
}
