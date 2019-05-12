using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveInput : MonoBehaviour, InputBlock {
    public GameObject jewelPrefab;

    public bool isLeftInput;
    private HashSet<Jewel> set;

    public void InputSet(HashSet<Jewel> inputSet) {
        set = inputSet;
        GetComponentInParent<Operator>().InputSet(set, isLeftInput);
        if (inputSet != null) populateView(inputSet);
    }

    private void populateView(HashSet<Jewel> inputSet)
    {
        Jewel[] jewels = new Jewel[inputSet.Count];
        inputSet.CopyTo(jewels);
        // TODO: will probably have to change these to accompany multiple amounts of sets
        float offset = .2f;
        float xOffset = .1f;
        float yOffset = .15f;
        float scaleFactor = .5f;
        for (int i = 0; i < inputSet.Count; i++)
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
