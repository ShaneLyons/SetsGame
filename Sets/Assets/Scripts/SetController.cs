using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using JewelEnum;

public class SetController : MonoBehaviour
{
	private HashSet<GameObject> jewels;
    private SpriteRenderer sprite;
    private Collider2D hitbox;
    private float startPositionX;
    private float startPositionY;

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

        hitbox = GetComponent<Collider2D>();

        startPositionX = transform.position.x;
        startPositionY = transform.position.y;
    }

    public void FixedUpdate()
    {
        if (transform.position.y < -7f)
        {
            GetComponent<PhysicsObject>().ResetVelocity();
            transform.position = new Vector2(startPositionX, startPositionY);
        }
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

    public void hideCollider()
    {
        hitbox.enabled = false;
    }

    public void showCollider()
    {
        hitbox.enabled = true;
    }

    //Respawn sets when fall off screen
    // public void OnBecameInvisible()
    // {
    //     if (sprite.transform.position.y < -7f)
    //     {
    //         sprite.transform.position = new Vector2(startPositionX, startPositionY);
    //     }
    // }
}
