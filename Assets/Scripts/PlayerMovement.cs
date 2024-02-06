using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D playerRigid;
    Animator anim;
    Vector2 moveInput;
    CapsuleCollider2D playerCollider;

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
        playerCollider = GetComponent<CapsuleCollider2D>();
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
        if (!playerCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) return;

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
        if (!playerCollider.IsTouchingLayers(LayerMask.GetMask("Climbing"))) return;

        Vector2 climbVelocity = new Vector2(playerRigid.velocity.x, moveInput.y * climbSpeed);
        playerRigid.velocity = climbVelocity;
    }
}
