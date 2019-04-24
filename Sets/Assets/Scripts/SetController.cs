using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using JewelEnum;

public class SetController : MonoBehaviour
{
	private HashSet<GameObject> jewels;
    private SpriteRenderer sprite;

    void Start()
    {
        // set up set from children under the set
		jewels = new HashSet<GameObject>();
    	foreach (Transform child in transform) {
			if (child.tag == "Jewel") {
				jewels.Add(child.gameObject);
			}
		}

        // we'll need this to hide the set later
        sprite = GetComponent<SpriteRenderer>();
    }

    public HashSet<Jewel> getJewels() {
		HashSet<Jewel> returnJewels = new HashSet<Jewel>();
		foreach (GameObject jewel in jewels) {
			returnJewels.Add(jewel.GetComponent<JewelController>().getType());
		}
		return returnJewels;
	}

    public void hideSet()
    {
        sprite.enabled = false;
        foreach (GameObject jewel in jewels) {
            jewel.GetComponent<JewelController>().hideJewel();
        }
    }

    public void showSet()
    {
        sprite.enabled = true;
        foreach (GameObject jewel in jewels)
        {
            jewel.GetComponent<JewelController>().showJewel();
        }
    }
}
