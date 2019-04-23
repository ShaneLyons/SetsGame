﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnionIntersectDifference : MonoBehaviour, Operator {
    public enum Operators {
        Union,
        Intersect,
        Difference
    }

    public Operators type;
    private HashSet<Jewel> leftSet;
    private HashSet<Jewel> rightSet;
    public GameObject outputObject;
    private InputBlock output;

    // Start is called before the first frame update
    void Start() {
        output = outputObject.GetComponent<InputBlock>();
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
        HashSet<Jewel> outputSet = new HashSet<Jewel>();
        switch (type) {
            case Operators.Union:
                outputSet.UnionWith(leftSet);
                outputSet.UnionWith(rightSet);
                output.InputSet(outputSet);
                break;
            case Operators.Intersect:
                outputSet.UnionWith(leftSet);
                outputSet.IntersectWith(rightSet);
                output.InputSet(outputSet);
                break;
            case Operators.Difference:
                outputSet.UnionWith(leftSet);
                foreach (Jewel jewel in rightSet) {
                    if (rightSet.Contains(jewel)) {
                        rightSet.Remove(jewel);
                    }
                }
                break;
        }
    }
}
