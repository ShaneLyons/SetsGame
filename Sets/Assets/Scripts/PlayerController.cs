using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ripped from https://unity3d.com/learn/tutorials/topics/2d-game-creation/scripting-gravity
public class PlayerController : PhysicsObject
{
    [SerializeField]
    public const float maxSpeed = 2;
    [SerializeField]
    public const float jumpTakeOffSpeed = 3;

    public Transform graphics;
    public Animator anim;

    public const string RUNNING = "Running";
    public const string JUMP = "Jump";
    public const string FALLING = "Falling";

    private bool facingRight = true;

    private float startPositionX;
    private float startPositionY;

    private void Start()
    {
        startPositionX = anim.transform.position.x;
        startPositionY = anim.transform.position.y;
    }

    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis("Horizontal");

        // regular jump
        if (Input.GetKeyDown(KeyCode.UpArrow) && grounded)
        {
            anim.SetTrigger(JUMP);
            velocity.y = jumpTakeOffSpeed;
        }

        // double jump
        else if (Input.GetKeyDown(KeyCode.UpArrow) && doubleJump)
        {
            anim.SetTrigger(JUMP);
            doubleJump = false;
            velocity.y = jumpTakeOffSpeed;
        }

        // graphics

        // flip sprite
        bool flipSprite = facingRight ? (move.x < -0.01f):(move.x > 0.01f);
        if (flipSprite)
        {
            facingRight = !facingRight;
            graphics.localScale = new Vector3(-1*graphics.localScale.x, graphics.localScale.y, graphics.localScale.z);
        }

        //change to running animation
        if (Mathf.Abs(move.x) > 0.1f)
        {
            anim.SetBool(RUNNING, true);
        } else
        {
            anim.SetBool(RUNNING, false);
        }

        // set falling to false on land
        if (grounded && anim.GetBool(FALLING))
        {
            anim.SetBool(FALLING, false);
        }

        // set falling to true on fall
        if (!grounded && !anim.GetBool(FALLING))
        {
            anim.SetBool(FALLING, true);
        }
        
        //If fall off screen
        if (transform.position.y < -7f)
        {
            transform.SetPositionAndRotation(new Vector3(startPositionX, startPositionY, 0), Quaternion.identity);
            velocity.y = 0;
            GetComponent<PlayerFadeIn>().FadeIn();
        }

        targetVelocity = move * maxSpeed;
    }
}
