﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// ripped from https://unity3d.com/learn/tutorials/topics/2d-game-creation/scripting-gravity
public class PhysicsObject : MonoBehaviour
{
    // used to tweak what's registered as ground vs wall
    public const float minGroundNormalY = .65f;

    [SerializeField]
    public float gravityModifier = 1f;
    [SerializeField]
    private bool contactForTriggers = false;

    // api for subclasses
    protected Vector2 targetVelocity;

    // logic for jumping
    protected bool grounded;
    protected bool doubleJump;
    protected Vector2 groundNormal;

    // logic for collision
    protected Rigidbody2D rb2d;
    protected ContactFilter2D contactFilter;
    protected RaycastHit2D[] hitBuffer = new RaycastHit2D[16];
    protected List<RaycastHit2D> hitBufferList = new List<RaycastHit2D>(16);
    protected const float minMoveDistance = 0.001f;
    protected const float shellRadius = 0.01f;

    protected Vector2 velocity;

    void OnEnable()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        // pass in game object layer for collisions
        contactFilter.useTriggers = contactForTriggers;
        contactFilter.SetLayerMask(Physics2D.GetLayerCollisionMask(gameObject.layer));
        contactFilter.useLayerMask = true;

        doubleJump = true;
    }

    void Update()
    {
        targetVelocity = Vector2.zero;
        ComputeVelocity();
    }

    protected virtual void ComputeVelocity()
    {
        // this will have to be implemented by any subclasses that want to define movement
    }

    void FixedUpdate()
    {
        velocity += gravityModifier * Physics2D.gravity * Time.deltaTime;

        velocity.x = targetVelocity.x;

        grounded = false;

        Vector2 deltaPosition = velocity * Time.deltaTime;
        Vector2 moveAlongGround = new Vector2(groundNormal.y, -groundNormal.x);

        // horizontal movement
        Vector2 move = moveAlongGround * deltaPosition.x;
        Movement(move, false);

        // vertical movement
        move = Vector2.up * deltaPosition.y;
        Movement(move, true);
    }

    public void ResetVelocity()
    {
        velocity = Vector2.zero;
    }

    void Movement(Vector2 move, bool yMovement)
    {
        float distance = move.magnitude;

        if (distance > minMoveDistance)
        {
            int count = rb2d.Cast(move, contactFilter, hitBuffer, distance + shellRadius);
            hitBufferList.Clear();

            for (int i=0; i<count; i++)
            {
                hitBufferList.Add(hitBuffer[i]);
            }

            for (int i=0; i<hitBufferList.Count; i++)
            {
                if (hitBufferList[i].collider.tag == "Player" && gameObject.tag == "Set")
                {
                    continue;
                }
                Vector2 currentNormal = hitBufferList[i].normal;

                // matters for slopes
                if (currentNormal.y > minGroundNormalY)
                {
                    grounded = true;
                    doubleJump = true;
                    if (yMovement)
                    {
                        groundNormal = currentNormal;
                        currentNormal.x = 0;
                    }
                }

                float projection = Vector2.Dot(velocity, currentNormal);
                if (projection < 0)
                {
                    velocity -= projection * currentNormal;
                }

                float modifiedDistance = hitBufferList[i].distance - shellRadius;
                distance = modifiedDistance < distance ? modifiedDistance : distance;
            }
        }

        Vector2 travel = move.normalized * distance;
        transform.position += new Vector3(travel.x, travel.y, transform.position.z);
        rb2d.position += travel;
    }
}
