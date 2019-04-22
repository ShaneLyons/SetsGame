using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using JewelEnum;

public class SetController : MonoBehaviour
{
		private HashSet<GameObject> jewels;

    void Start()
    {
			jewels = new HashSet<GameObject>();
    	foreach (Transform child in transform) {
				if (child.tag == "Jewel") {
					jewels.Add(child.gameObject);
				}
			}
    }

    public HashSet<Jewel> getJewels() {
			HashSet<Jewel> returnJewels = new HashSet<Jewel>();
			foreach (GameObject jewel in jewels) {
				returnJewels.Add(jewel.GetComponent<JewelController>().getType());
			}
			return returnJewels;
		}
}
