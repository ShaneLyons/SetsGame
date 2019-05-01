using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveInput : MonoBehaviour, InputBlock {
    public bool isLeftInput;
    private HashSet<Jewel> set;

    public void InputSet(HashSet<Jewel> inputSet) {
        set = inputSet;
        GetComponentInParent<Operator>().InputSet(set, isLeftInput);
        // take this out later, I added this for class playtest
        if (inputSet.Count == 2)
        {
            GetComponentInChildren<SetController>().showSet();
        }
    }
}
