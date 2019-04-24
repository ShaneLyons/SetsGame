using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveInput : MonoBehaviour, InputBlock {
    [SerializeField]
    public bool isLeftInput;
    private HashSet<Jewel> set;
    //public GameObject operatorOutput;

    // to keep track of what's in the input
    private bool holdingSet;
    private SetController heldSet;

    void Start()
    {
        holdingSet = false;
    }

    //Player places block
    public void PlaceSet(SetController inputSet) {
        set = inputSet.getJewels();
        heldSet = inputSet;
        holdingSet = true;
        InputSet(set);
    }

    //Player removes block
    public SetController RemoveSet() {
        // little fix for now, should improve later
        InputSet(null);
        holdingSet = false;
        return heldSet;
    }

    public void InputSet(HashSet<Jewel> set) {
        GetComponentInParent<Operator>().InputSet(set, isLeftInput);
    }

    public bool holdsSet() {
        return holdingSet;
    }
}
