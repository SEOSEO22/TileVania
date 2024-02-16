using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 1f;

    Rigidbody2D enemyRigid;

    private void Start()
    {
        enemyRigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        enemyRigid.velocity = new Vector2(moveSpeed, 0f);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        moveSpeed = -moveSpeed;
        FlipEnemySprite();
    }

    private void FlipEnemySprite()
    {
        transform.localScale = new Vector2(Mathf.Sign(moveSpeed), transform.localScale.y);
    }
}


