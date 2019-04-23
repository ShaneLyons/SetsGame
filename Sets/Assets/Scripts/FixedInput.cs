using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedInput : MonoBehaviour, InputBlock {
    public bool isLeftInput;
    public Jewel jewel1;
    public Jewel jewel2;
    public Jewel jewel3;
    public Jewel jewel4;
    public Jewel jewel5;
    public Jewel jewel6;
    private HashSet<Jewel> set;
    public GameObject operatorOutput;
    private Operator operatorComponent;

    void Start() {
        set = new HashSet<Jewel>();
        Jewel[] jewels = {jewel1, jewel2, jewel3, jewel4, jewel5, jewel6};
        foreach(Jewel jewel in jewels){
            //if(jewel != Jewel.White){
            set.Add(jewel);
            //}
        }
        operatorComponent = operatorOutput.GetComponentInParent<Operator>();
        operatorComponent.InputSet(set, isLeftInput);
    }

    public void InputSet(HashSet<Jewel> inputSet) {
        operatorOutput.GetComponent<Operator>().InputSet(set, isLeftInput);
    }
}
