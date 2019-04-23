using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetInteraction : MonoBehaviour
{
    // we'll be using box colliders to tell if we're overlapping with a set
    private BoxCollider2D hitbox;
    private bool holdingSet;
    private SetController heldSet;

    void Start()
    {
        hitbox = GetComponent<BoxCollider2D>();
        holdingSet = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Set") {
            if (Input.GetKey(KeyCode.Space) && !holdingSet) {
                holdingSet = true;
                heldSet = collision.GetComponent<SetController>();
                heldSet.hideSet();
            }
        }
    }
}
