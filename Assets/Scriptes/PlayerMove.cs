using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rb;

    public float moveSpeed;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        PMove();
        Jump();
    }

    private void PMove() // Передвижение персонажа по горизонтале
    {
        float moveVelocity = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveVelocity * moveSpeed, rb.velocity.y);
    }

    //Прыжок игрока

    public float jumpForce = 40f;
    private short jumpCount = 0;
    public float doubleJumpVelocity = 10f;

    private void Jump() // Обработка прыжка, идея реализовать через событие
    {
        //-------------------------
        if (Input.GetKeyDown(KeyCode.Space) && IsGround.onGround)
        {
            rb.AddForce(Vector2.up * jumpForce);
            jumpCount = 0;
        }
        //-------------------------
        if (!IsGround.onGround && Input.GetKeyDown(KeyCode.Space) && jumpCount == 0)
            {
                rb.velocity = new Vector2(0, doubleJumpVelocity);
                jumpCount++;
            }
        //-------------------------
    }
}
