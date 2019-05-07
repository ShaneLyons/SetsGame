using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    private Vector3 goalPosition;
    private Vector3 startPosition;

    private bool opened;

    void Start()
    {
        startPosition = transform.position;
        goalPosition = startPosition + new Vector3(0, 2, 0);
        opened = false;
    }

    public void raiseDoor() {
        opened = true;
    }

    void FixedUpdate()
    {
        float t = .1f;
        if (opened)
        {
            transform.position = Vector3.Lerp(transform.position, goalPosition, t);
        }
    }
}
