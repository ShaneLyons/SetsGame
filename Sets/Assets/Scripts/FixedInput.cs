using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedInput : MonoBehaviour, InputBlock {
    public bool isLeftInput;

    [SerializeField]
    private static int setSize = 3;
    public Jewel[] jewels = new Jewel[setSize];

    void Start() {
        HashSet<Jewel> set = new HashSet<Jewel>(jewels);
        InputSet(set);
    }

    public void InputSet(HashSet<Jewel> inputSet) {
        GetComponentInParent<Operator>().InputSet(inputSet, isLeftInput);
    }

    private void populateView()
    {

    }
}
