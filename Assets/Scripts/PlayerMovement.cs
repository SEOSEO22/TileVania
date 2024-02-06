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
    }

    private void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    private void OnJump(InputValue value)
    {
        if (value.isPressed && playerCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
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
}
