using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedInput : MonoBehaviour, InputBlock {
    public bool isLeftInput;
    public GameObject jewelPrefab;

    // used for setting up the set
    [SerializeField]
    private static int setSize = 2;
    public Jewel[] jewels = new Jewel[setSize];

    void Start() {
        HashSet<Jewel> set = new HashSet<Jewel>(jewels);
        InputSet(new HashSet<Jewel>(set));
        populateView(set);
    }

    public void InputSet(HashSet<Jewel> inputSet) {
        GetComponentInParent<Operator>().InputSet(inputSet, isLeftInput);
    }

    private void populateView(HashSet<Jewel> inputSet)
    {
        // TODO: will probably have to change these to accompany multiple amounts of sets0
        float offset = .2f;
        float xOffset = .1f;
        float yOffset = .15f;
        float scaleFactor = .5f;
        for (int i=0; i < setSize; i++)
        {
            GameObject jewelSprite = Instantiate(jewelPrefab, transform);
            jewelSprite.GetComponent<JewelController>().setColor(jewels[i]);
            Vector3 scale = jewelSprite.transform.localScale;
            Vector3 pos = jewelSprite.transform.position;
            jewelSprite.transform.localScale = new Vector3(scale.x * .5f, scale.y, scale.z) * scaleFactor;
            jewelSprite.transform.position = new Vector3(pos.x - xOffset + offset * i, pos.y + yOffset, pos.z);
        }
    }
}
