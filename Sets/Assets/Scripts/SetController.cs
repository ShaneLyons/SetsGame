using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using JewelEnum;

public class SetController : MonoBehaviour
{
	public Jewel j1, j2, j3, j4, j5, j6;
	private HashSet<Jewel> jewels;

    // Start is called before the first frame update
    void Start()
    {
    	jewels = new HashSet<Jewel>();
        jewels.Add(j1);
        jewels.Add(j2);
        jewels.Add(j3);
        jewels.Add(j4);
        jewels.Add(j5);
        jewels.Add(j6);

        SpriteRenderer[] sprites = GetComponentsInChildren<SpriteRenderer>();
        Debug.Log(sprites);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
