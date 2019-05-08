using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, Goal {

    private Vector3 goalPosition;
    private Vector3 startPosition;

    private bool opened;

    void Start()
    {
        startPosition = transform.position;
        goalPosition = startPosition + new Vector3(0, 2, 0);
        opened = false;
    }

    public void SuccessState() {
        opened = true;
    }

    public void FailureState()
    {
        opened = false;
    }

    void FixedUpdate()
    {
        float t = .1f;
        transform.position = opened ? Vector3.Lerp(transform.position, goalPosition, t) : Vector3.Lerp(transform.position, startPosition, t);
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
