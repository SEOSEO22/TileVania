using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D playerRigid;
    Vector2 moveInput;

    [SerializeField]
    float pMoveSpeed = 5f;

    private void Start()
    {
        playerRigid = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        Run();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void Run()
    {
        Vector2 pVelocity = new Vector2(moveInput.x * pMoveSpeed, playerRigid.velocity.y);
        playerRigid.velocity = pVelocity;
    }
}
