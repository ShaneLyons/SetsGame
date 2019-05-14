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
    public int visualSize;

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
        Dictionary<string, float> offsets = JewelOffsets.GetOffsets(inputSet.Count);
        float xOffset = offsets["xOffset"];
        float yOffset = offsets["yOffset"];
        float xDiff = offsets["xDiff"];
        float yDiff = offsets["yDiff"];
        float scaleFactor = offsets["scaleFactor"];

        for (int i=0; i < visualSize; i++)
        {
            GameObject jewelSprite = Instantiate(jewelPrefab, transform);
            jewelSprite.GetComponent<JewelController>().setColor(jewels[i]);
            Vector3 scale = jewelSprite.transform.localScale;
            Vector3 pos = jewelSprite.transform.position;
            jewelSprite.transform.localScale = new Vector3(scale.x * .5f, scale.y, scale.z) * scaleFactor;
            float yWave = (i % 2 == 1) ? yDiff : 0;
            jewelSprite.transform.position = new Vector3(pos.x - xOffset + xDiff * i, pos.y + yOffset + yWave, pos.z);
        }
    }
}
