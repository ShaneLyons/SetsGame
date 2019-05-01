using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, Goal {

    public Material successTexture;
    public Material failTexture;

    private Vector2 goalPosition;

    void Start() {
        GetComponent<Renderer>().material = successTexture;
        InputResult(false);
        goalPosition = transform.position;
    }

    public void InputResult(bool isCorrect){
        if (isCorrect) {
            SuccessState();
        } else {
            FailureState();
        }
    }

    void Update()
    {
        transform.position = goalPosition;
    }

    public void SuccessState() {
        GetComponent<Renderer>().material = successTexture;
        goalPosition = (Vector2) transform.position + new Vector2(0, 2);
    }

    public void FailureState() {
        GetComponent<Renderer>().material = failTexture;
    }
}
