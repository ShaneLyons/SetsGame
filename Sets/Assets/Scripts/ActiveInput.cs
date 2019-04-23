using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveInput : MonoBehaviour, InputBlock {
    public bool isLeftInput;
    private HashSet<Jewel> set;
    public GameObject operatorOutput;

    //Player places block
    public void PlaceSet(SetController inputSet) {
        set = inputSet.getJewels();
        InputSet(set);
    }

    //Player removes block
    public void RemoveSet(SetController set) {
        InputSet(new HashSet<Jewel>());
    }

    public void InputSet(HashSet<Jewel> set) {
        operatorOutput.GetComponentInParent<Operator>().InputSet(set, isLeftInput);
    }
}
