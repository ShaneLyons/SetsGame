using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, Goal {

    public Material successTexture;
    public Material failTexture;

    // remove this after playtest
    private Vector2 goalPosition;

    void Start() {
        GetComponent<Renderer>().material = successTexture;
        InputResult(false);
        // remove this after playtest
        goalPosition = transform.position;
    }

    public void InputResult(bool isCorrect){
        if (isCorrect) {
            SuccessState();
        } else {
            FailureState();
        }
    }

    // remove this after playtest
    void Update()
    {
        transform.position = goalPosition;
    }

    public void SuccessState() {
        GetComponent<Renderer>().material = successTexture;
        // remove this after playtest
        goalPosition = (Vector2) transform.position + new Vector2(0, 2);
    }

    public void FailureState() {
        GetComponent<Renderer>().material = failTexture;
    }
}
