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
        heldSet.transform.localScale = new Vector3((heldSet.transform.localScale.x)*0.7f, (heldSet.transform.localScale.y) * 0.7f, 0); //resizes smaller
        heldSet.hideCollider();
        FindObjectOfType<AudioManagerController>().Play("PlaceSet");
        InputSet(set);
    }

    //Player removes block
    public SetController RemoveSet() {
        // little fix for now, should improve later
        InputSet(null);
        holdingSet = false;
        heldSet.transform.localScale = new Vector3((heldSet.transform.localScale.x) * (10f/7f), (heldSet.transform.localScale.y) * (10f/7f), 0); //resizes to original size
        heldSet.showCollider();
        return heldSet;
    }

    public void InputSet(HashSet<Jewel> set) {
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
