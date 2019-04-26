using System.Collections.Generic;
using UnityEngine;

public class SetInteraction : MonoBehaviour
{
    // we'll be using box colliders to tell if we're overlapping with a set
    private BoxCollider2D hitbox;
    private bool holdingSet;
    private SetController heldSet;

    // more efficient to only check when we enter and exit objects
    List<Collider2D> colliders = new List<Collider2D>();

    // make sure we don't immediately pick up what we drop
    bool pickedUp;

    void Start()
    {
        hitbox = GetComponent<BoxCollider2D>();
        holdingSet = false;
        pickedUp = false;
    }

    void Update()
    {
        if (colliders.Count > 0)
        {
            collideRoutine(colliders);
        }

        if (holdingSet)
        {
            heldSet.transform.position = ((Vector2) gameObject.transform.position + new Vector2(0, 1));
            // dropping a set
            if (Input.GetKeyDown(KeyCode.Space) && !pickedUp)
            {
                holdingSet = false;
                heldSet.transform.position = newSetPosition();
            }
        }

        pickedUp = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        colliders.Add(collision);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        colliders.Remove(collision);
    }

    void collideRoutine(List<Collider2D> collisions)
    {
        Collider2D collision = getCollider(collisions);
        if (collision.tag == "Input")
        {
            ActiveInput input = collision.GetComponent<ActiveInput>();
            // placing a set into an input
            if (Input.GetKeyDown(KeyCode.Space) && holdingSet)
            {
                holdingSet = false;
                heldSet.hideSet();
                SetController currentSet = heldSet;
                // in case there's an old set in the input
                if (input.holdsSet())
                {
                    pickupSetFromInput(input);
                }
                input.PlaceSet(currentSet);

            // picking up a set from the input
            }
            else if (Input.GetKeyDown(KeyCode.Space) && !holdingSet)
            {
                if (input.holdsSet())
                {
                    pickupSetFromInput(input);
                }
            }
        // picking up a set
        } else if (collision.tag == "Set") {
            if (Input.GetKeyDown(KeyCode.Space)) {
                SetController nextSet = collision.GetComponent<SetController>();
                if (holdingSet)
                {
                    heldSet.transform.position = gameObject.transform.position;
                }
                heldSet = nextSet;
                heldSet.transform.position = (Vector2)gameObject.transform.position + new Vector2(0, 1);
                holdingSet = true;
                pickedUp = true;
            }
        }
    }

    private Collider2D getCollider(List<Collider2D> collisions)
    {
        foreach (Collider2D collision in collisions)
        {
            if (collision.tag == "Input")
            {
                return collision;
            }
        }
        return collisions[0];
    }

    private void pickupSetFromInput(ActiveInput input)
    {
        holdingSet = true;
        heldSet = input.RemoveSet();
        heldSet.showSet();
        heldSet.transform.position = ((Vector2)gameObject.transform.position + new Vector2(0, 1));
        pickedUp = true;
    }

    private Vector2 newSetPosition()
    {
        return gameObject.transform.position;
    }
}
