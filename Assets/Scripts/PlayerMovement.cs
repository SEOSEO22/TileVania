using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    float startGravity;
    Vector2 moveInput;
    Rigidbody2D playerRigid;
    Animator anim;
    CapsuleCollider2D playerBodyCollider;
    BoxCollider2D playerFeetCollider;

    [SerializeField]
    float pMoveSpeed = 5f;
    [SerializeField]
    float jumpForce = 10f;
    [SerializeField]
    float climbSpeed = 10f;

    private void Start()
    {
        playerRigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        playerBodyCollider = GetComponent<CapsuleCollider2D>();
        playerFeetCollider = GetComponent<BoxCollider2D>();
        startGravity = playerRigid.gravityScale;
    }

    private void Update()
    {
        Run();
        FlipSprite();
        ClimbLadder();
    }

    private void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    private void OnJump(InputValue value)
    {
        if (!playerFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) return;

        if (value.isPressed)
        {
            playerRigid.velocity += new Vector2(0f, jumpForce);
        }
    }

    private void Run()
    {
        Vector2 pVelocity = new Vector2(moveInput.x * pMoveSpeed, playerRigid.velocity.y);
        playerRigid.velocity = pVelocity;

        bool isPlayerMove = Mathf.Abs(moveInput.x) > Mathf.Epsilon;
        anim.SetBool("isRunning", isPlayerMove);
    }

    void FlipSprite()
    {
        bool isPlayerMove = Mathf.Abs(moveInput.x) > Mathf.Epsilon;

        if (isPlayerMove)
        {
            transform.localScale = new Vector2(Mathf.Sign(moveInput.x), transform.localScale.y);
        }
    }

    void ClimbLadder()
    {
        if (!playerFeetCollider.IsTouchingLayers(LayerMask.GetMask("Climbing")))
        {
            playerRigid.gravityScale = startGravity;
            anim.SetBool("isClimbing", false);
            return;
        }

        Vector2 climbVelocity = new Vector2(playerRigid.velocity.x, moveInput.y * climbSpeed);
        playerRigid.velocity = climbVelocity;
        playerRigid.gravityScale = 0f;

        bool isPlayerClimb = Mathf.Abs(playerRigid.velocity.y) > Mathf.Epsilon;
        anim.SetBool("isClimbing", isPlayerClimb);
    }
}
