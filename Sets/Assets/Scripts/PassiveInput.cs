using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveInput : MonoBehaviour, InputBlock {
    public GameObject jewelPrefab;

    public bool isLeftInput;
    private HashSet<Jewel> set;

    private HashSet<GameObject> sprites = new HashSet<GameObject>();

    public void InputSet(HashSet<Jewel> inputSet) {
        set = inputSet;
        GetComponentInParent<Operator>().InputSet(set, isLeftInput);
       
        populateView(inputSet);
    }

    private void populateView(HashSet<Jewel> inputSet)
    {
        if (inputSet is null)
        {
            return;
        }
        depopulateView(sprites);
        Jewel[] jewels = new Jewel[inputSet.Count];
        inputSet.CopyTo(jewels);

        Dictionary<string, float> offsets = JewelOffsets.GetOffsets(inputSet.Count);
        float xOffset = offsets["xOffset"];
        float yOffset = offsets["yOffset"];
        float xDiff = offsets["xDiff"];
        float yDiff = offsets["yDiff"];
        float scaleFactor = offsets["scaleFactor"];

        for (int i = 0; i < inputSet.Count; i++)
        {
            GameObject jewelSprite = Instantiate(jewelPrefab, transform);
            jewelSprite.GetComponent<JewelController>().setColor(jewels[i]);
            Vector3 scale = jewelSprite.transform.localScale;
            Vector3 pos = jewelSprite.transform.position;
            jewelSprite.transform.localScale = new Vector3(scale.x * .5f, scale.y, scale.z) * scaleFactor;
            float yWave = (i % 2 == 1) ? yDiff : 0;
            jewelSprite.transform.position = new Vector3(pos.x - xOffset + xDiff * i, pos.y + yOffset + yWave, pos.z);
            sprites.Add(jewelSprite);
        }
    }

    private void depopulateView(HashSet<GameObject> sprites)
    {
        foreach (GameObject sprite in sprites)
        {
            Destroy(sprite);
        }
        sprites = new HashSet<GameObject>();
    }
}
