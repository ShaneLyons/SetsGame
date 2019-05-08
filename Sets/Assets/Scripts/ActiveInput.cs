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

    void Update()
    {
        if (holdingSet)
        {
            heldSet.transform.position = (Vector2)transform.position + new Vector2(0, 0.6f);
        }
    }

    //Player places block
    public void PlaceSet(SetController inputSet) {
        set = inputSet.getJewels();
        heldSet = inputSet;
        holdingSet = true;
        heldSet.transform.position = (Vector2) transform.position + new Vector2(0, 0.5f);
        heldSet.hideCollider();
        InputSet(set);
    }

    //Player removes block
    public SetController RemoveSet() {
        // little fix for now, should improve later
        InputSet(null);
        holdingSet = false;
        heldSet.showCollider();
        return heldSet;
    }

    public void InputSet(HashSet<Jewel> set) {
        Debug.Log("Inputted set: ");
        setToString(set);
        GetComponentInParent<Operator>().InputSet(set, isLeftInput);
    }

    public void setToString(HashSet<Jewel> set)
    {
        string colors = "";
        foreach (Jewel jewel in set)
        {
            colors += jewel.ToString() + ", ";
        }
        Debug.Log(colors);
    }

    public bool holdsSet() {
        return holdingSet;
    }
}
