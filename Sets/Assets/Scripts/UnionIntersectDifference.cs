using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnionIntersectDifference : MonoBehaviour, Operator
{
    public enum Operators
    {
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
    private LightRope rope;

    void Start()
    {
        rope = GetComponentInChildren<LightRope>();
        output = outputObject.GetComponent<InputBlock>();
        leftSet = null;
        rightSet = null;
    }

    public void InputSet(HashSet<Jewel> set, bool leftInput)
    {
        if (leftInput)
        {
            leftSet = set;
        }
        else
        {
            rightSet = set;
        }

        if (leftSet != null && rightSet != null)
        {
            if (rope) rope.TurnOn();
        }
        else
        {
            if (rope) rope.TurnOff();
        }

        HashSet<Jewel> outputSet = new HashSet<Jewel>();
        switch (type)
        {
            case Operators.Union:
                if (leftSet == null && rightSet == null)
                {
                    output.InputSet(null);
                }
                else
                {
                    if (leftSet == null) leftSet = new HashSet<Jewel>();
                    if (rightSet == null) rightSet = new HashSet<Jewel>();
                    outputSet.UnionWith(leftSet);
                    outputSet.UnionWith(rightSet);
                    //Debug.Log("Union left: ");
                    //setToString(leftSet);
                    //Debug.Log("Union right: ");
                    //setToString(rightSet);
                    output.InputSet(outputSet);
                    //Debug.Log("Union output: ");
                    //setToString(outputSet);
                }
                break;
            case Operators.Intersect:
                if (leftSet == null || rightSet == null)
                {
                    output.InputSet(null);
                }
                else
                {
                    outputSet.UnionWith(leftSet);
                    outputSet.IntersectWith(rightSet);
                    output.InputSet(outputSet);
                    //Debug.Log("Intersect output: ");
                    //setToString(outputSet);
                }
                break;
            case Operators.Difference:
                if (rightSet == null)
                {
                    output.InputSet(null);
                }
                else
                {
                    if (leftSet == null) leftSet = new HashSet<Jewel>();
                    foreach (Jewel jewel in leftSet)
                    {
                        if (!rightSet.Contains(jewel))
                        {
                            outputSet.Add(jewel);
                        }
                    }
                    output.InputSet(outputSet);
                    //Debug.Log("Difference output: ");
                    //setToString(outputSet);
                }
                break;
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
