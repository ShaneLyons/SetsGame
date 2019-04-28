using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, Goal {

    public Material successTexture;
    public Material failTexture;

    void Start() {
        GetComponent<Renderer>().material = successTexture;
        InputResult(false);
    }

    public void InputResult(bool isCorrect){
        if (isCorrect) {
            SuccessState();
        } else {
            FailureState();
        }
    }

    public void SuccessState() {
        GetComponent<Renderer>().material = successTexture;
    }

    public void FailureState() {
        GetComponent<Renderer>().material = failTexture;
    }
}
