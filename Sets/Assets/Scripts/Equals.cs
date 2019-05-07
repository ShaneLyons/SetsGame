using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equals : MonoBehaviour, Operator {
    private HashSet<Jewel> leftSet;
    private HashSet<Jewel> rightSet;
    public GameObject outputObject;
    private Door output;

    // Start is called before the first frame update
    void Start() {
        output = outputObject.GetComponent<Door>();
        leftSet = new HashSet<Jewel>();
        rightSet = new HashSet<Jewel>();
    }

    public void InputSet(HashSet<Jewel> set, bool leftInput) {
        if (leftInput) {
            leftSet = set;
        }
        else {
            rightSet = set;
        }
        bool outputValue = leftSet.SetEquals(rightSet);
        output.raiseDoor();
    }
}
