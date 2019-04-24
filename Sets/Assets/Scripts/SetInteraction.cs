using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetInteraction : MonoBehaviour
{
    // we'll be using box colliders to tell if we're overlapping with a set
    private BoxCollider2D hitbox;
    private bool holdingSet;
    private SetController heldSet;

    // needed to make sure we don't pick up an object again too fast
    [SerializeField]
    private float pickupTimeout = .2f;
    private float cooldown;

    void Start()
    {
        hitbox = GetComponent<BoxCollider2D>();
        holdingSet = false;
        cooldown = 0;
    }

    void Update()
    {
        if (holdingSet) {
            heldSet.transform.position = ((Vector2) gameObject.transform.position + new Vector2(0, 1));

            if (Input.GetKeyDown(KeyCode.Space)) {
                heldSet.transform.position = newSetPosition();
                holdingSet = false;
                cooldown = 0;
            }
        } else {
            if (cooldown < pickupTimeout) {
                cooldown += Time.deltaTime;
            }
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Set") {
            if (Input.GetKeyUp(KeyCode.Space) && !holdingSet) {
                SetController possibleSet = collision.GetComponent<SetController>();
                // make sure we don't immediately pick up the same set
                if (heldSet != possibleSet || cooldown >= pickupTimeout) {
                    holdingSet = true;
                    heldSet = possibleSet;
                    heldSet.transform.position = ((Vector2)gameObject.transform.position + new Vector2(0, 1));
                }
            }
        }
    }

    private Vector2 newSetPosition() {
        return gameObject.transform.position;
    }
}
