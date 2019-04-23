using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveInput : MonoBehaviour, InputBlock {
    public bool isLeftInput;
    private HashSet<Jewel> set;
    public GameObject operatorOutput;

    public void InputSet(HashSet<Jewel> inputSet) {
        set = inputSet;
        operatorOutput.GetComponentInParent<Operator>().InputSet(set, isLeftInput);
    }
}
