using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equals : MonoBehaviour, Operator {
    private HashSet<Jewel> leftSet = null;
    private HashSet<Jewel> rightSet = null;
    public GameObject outputObject;
    private Goal output;
    private bool sidesEqual = false;

    // Start is called before the first frame update
    void Start() {
        // start is actually called after the first InputSet, leading to weird bugs
        // instead, I set them in the variable declaration
        //leftSet = null;
        //rightSet = null;
        sidesEqual = false;
    }

    public void InputSet(HashSet<Jewel> set, bool leftInput) {
        if (output is null)
        {
            output = outputObject.GetComponent<Goal>();
        }

        if (leftInput) {
            leftSet = set;
        }
        else {
            rightSet = set;
        }


        bool outputValue = leftSet != null && rightSet != null && leftSet.SetEquals(rightSet);

        if(outputValue) FindObjectOfType<AudioManagerController>().Play("PowerUp");

        if(!outputValue && sidesEqual){
            FindObjectOfType<AudioManagerController>().Play("PowerDown");
        }

        sidesEqual = outputValue;

        output.InputResult(outputValue);
    }
}
