using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ripped from https://unity3d.com/learn/tutorials/topics/2d-game-creation/scripting-gravity
public class PlayerController : PhysicsObject
{
    [SerializeField]
    public const float maxSpeed = 3;
    [SerializeField]
    public const float jumpTakeOffSpeed = 4;

    // used to cap how many total jumps we can do
    private int extraJumps;
    public const int maxExtraJumps = 2;

    public Transform graphics;
    public Animator anim;

    public const string RUNNING = "Running";

    private bool facingRight = true;

    void Start()
    {
        extraJumps = 0;
    }

    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis("Horizontal");

        // regular jump
        if (Input.GetKeyDown(KeyCode.UpArrow) && grounded)
        {
            velocity.y = jumpTakeOffSpeed;
            extraJumps = 0;
        }

        // wall jump
        else if (Input.GetKeyDown(KeyCode.UpArrow) && wallJump && extraJumps < 2)
        {
            velocity.y = jumpTakeOffSpeed;
            extraJumps++;
        }

        // double jump
        else if (Input.GetKeyDown(KeyCode.UpArrow) && doubleJump && extraJumps < 2)
        {
            doubleJump = false;
            velocity.y = jumpTakeOffSpeed;
            extraJumps++;
        }

        // how long velocity lasts
        else if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            if (velocity.y > 0)
            {
                velocity.y = velocity.y * 0.5f;
            }
        }

        // graphics

        // flip sprite
        bool flipSprite = facingRight ? (move.x < -0.01f):(move.x > 0.01f);
        if (flipSprite)
        {
            facingRight = !facingRight;
            graphics.localScale = new Vector3(-1*graphics.localScale.x, graphics.localScale.y, graphics.localScale.z);
        }

        Debug.Log(move);

        //change to running animation
        if (Mathf.Abs(move.x) > 0.1f)
        {
            anim.SetBool(RUNNING, true);
        } else
        {
            anim.SetBool(RUNNING, false);
        }

        targetVelocity = move * maxSpeed;
    }
}
