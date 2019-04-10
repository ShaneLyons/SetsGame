using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ripped from https://unity3d.com/learn/tutorials/topics/2d-game-creation/scripting-gravity
public class PlayerController : PhysicsObject
{
    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.UpArrow) && grounded)
        {
            velocity.y = jumpTakeOffSpeed;
        }

        else if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            if (velocity.y > 0)
            {
                velocity.y = velocity.y * 0.5f;
            }
        }

        bool flipSprite = (spriteRenderer.flipX ? (move.x > 0.01f) : (move.x < 0.01f));
        if (flipSprite)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

        targetVelocity = move * maxSpeed;
    }
}
