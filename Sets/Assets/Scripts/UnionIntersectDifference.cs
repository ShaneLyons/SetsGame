using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnionIntersectDifference : MonoBehaviour, Operator {
    public enum Operators {
        Union,
        Intersect,
        Difference
    }

    [SerializeField]
    public Operators type;
    private HashSet<Jewel> leftSet;
    private HashSet<Jewel> rightSet;
    public GameObject outputObject;
    private InputBlock output;

    // Start is called before the first frame update
    void Start() {
        output = outputObject.GetComponent<InputBlock>();
        leftSet = null;
        rightSet = null;
    }

    public void InputSet(HashSet<Jewel> set, bool leftInput) {
        if (leftInput) {
            leftSet = set;
        }
        else {
            rightSet = set;
        }
        
        if (leftSet != null && rightSet != null) {
            HashSet<Jewel> outputSet = new HashSet<Jewel>();
            /*Debug.Log("Left Set");
            setToString(leftSet);
            Debug.Log("right Set");
            setToString(rightSet);*/
            switch (type)
            {
                case Operators.Union:
                    outputSet.UnionWith(leftSet);
                    outputSet.UnionWith(rightSet);
                    output.InputSet(outputSet);
                    Debug.Log("output Set:");
                    setToString(outputSet);
                    break;
                case Operators.Intersect:
                    outputSet.UnionWith(leftSet);
                    outputSet.IntersectWith(rightSet);
                    output.InputSet(outputSet);
                    break;
                case Operators.Difference:
                    foreach (Jewel jewel in leftSet)
                    {
                        if (!rightSet.Contains(jewel))
                        {
                            outputSet.Add(jewel);
                        }
                    }
                    output.InputSet(outputSet);
                    break;
            }
        }
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
}
