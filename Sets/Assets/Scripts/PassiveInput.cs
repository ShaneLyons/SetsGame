using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveInput : MonoBehaviour, InputBlock {
    public bool isLeftInput;
    private HashSet<Jewel> set;

    public void InputSet(HashSet<Jewel> inputSet) {
        set = inputSet;
        GetComponentInParent<Operator>().InputSet(set, isLeftInput);
    }
}
