using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, Goal
{
    private Vector2 openPosition;
    private Vector2 startPosition;
    private bool moving;
    private bool open;
    public float openSpeed;

    void Start()
    {
        startPosition = (Vector2) transform.localPosition;
        openPosition = startPosition + new Vector2(0, 2);
        moving = false;
        open = false;
    }

    public void InputResult(bool isCorrect)
    {
        Debug.Log(isCorrect);
        if (isCorrect)
        {
            SuccessState();
        }
        else
        {
            FailureState();
        }
    }

    void Update()
    {
        if (moving)
        {
            float distanceToOpening;
            float yMovement;
            int direction;
            if (open)
            {
                distanceToOpening = openPosition.y - transform.localPosition.y;
                direction = 1;
            }
            else
            {
                distanceToOpening = transform.localPosition.y - startPosition.y;
                direction = -1;
            }
            yMovement = openSpeed * Time.deltaTime;
            if (distanceToOpening < yMovement)
            {
                yMovement = distanceToOpening;
                moving = false;
            }
            transform.position = transform.position + new Vector3(0, yMovement * direction, 0);

        }
    }

    public void SuccessState()
    {
        open = true;
        moving = true;
    }

    public void FailureState()
    {
        open = false;
        moving = true;
    }
}
