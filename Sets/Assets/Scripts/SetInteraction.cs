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

    Collider2D collider;
    bool collided;

    void Start()
    {
        hitbox = GetComponent<BoxCollider2D>();
        holdingSet = false;
        cooldown = 0;
        collided = false;
    }

    void Update()
    {
        if (collided) {
            collideRoutine(collider);
        }
        // little jank check if cooldown is zero which means we just dropped something into input
        if (holdingSet && cooldown != 0) {
            heldSet.transform.position = ((Vector2) gameObject.transform.position + new Vector2(0, 1));
            if (Input.GetKeyDown(KeyCode.Space)) {
                holdingSet = false;
                cooldown = 0;
                heldSet.transform.position = newSetPosition();
            }
        } else {
            if (cooldown < pickupTimeout) {
                cooldown += Time.deltaTime;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        collider = collision;
        collided = true;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        collided = false;    
    }

    void collideRoutine(Collider2D collision)
    {
        if (collision.tag == "Input")
        {
            ActiveInput input = collision.GetComponent<ActiveInput>();
            // placing a set
            if (Input.GetKeyDown(KeyCode.Space) && holdingSet)
            {
                holdingSet = false;
                heldSet.hideSet();
                SetController currentSet = heldSet;
                // in case there's an old set
                if (input.holdsSet())
                {
                    pickupSet(input);
                }
                input.PlaceSet(currentSet);
                cooldown = 0;

            // picking up a set
            }
            else if (Input.GetKeyUp(KeyCode.Space) && !holdingSet)
            {
                if (input.holdsSet() && cooldown >= pickupTimeout)
                {
                    pickupSet(input);
                }
            }
        } else if (collision.tag == "Set") {
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

    private void pickupSet(ActiveInput input)
    {
        holdingSet = true;
        heldSet = input.RemoveSet();
        heldSet.showSet();
        heldSet.transform.position = ((Vector2)gameObject.transform.position + new Vector2(0, 1));
    }

    private Vector2 newSetPosition()
    {
        return gameObject.transform.position;
    }
}
