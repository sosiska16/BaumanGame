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
        PlayerJump();
        PlatformDown();
        UpDownOnStairs();
    }

    private void FixedUpdate()
    {
        PlayerMoving();
    }
    //-------------------------------------------
    private void PlayerMoving() // Передвижение персонажа по горизонтале
    {
        float moveVelocity = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveVelocity * moveSpeed, rb.velocity.y);
    }

    //Прыжок игрока

    public float jumpForce = 40f;
    private short jumpCount = 0;
    public float doubleJumpVelocity = 10f;

    private void PlayerJump() // Обработка прыжка, идея реализовать через событие
    {
        //-------------------------
        if (Input.GetKeyDown(KeyCode.Space) && LayersChecker.onGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(Vector2.up * jumpForce);
            jumpCount = 0;
        }
        //-------------------------
        if (!LayersChecker.onGround && Input.GetKeyDown(KeyCode.Space) && jumpCount == 0)
            {
                rb.velocity = new Vector2(0, doubleJumpVelocity);
                jumpCount++;
            }
        //-------------------------
    }
    
   
    //Вызов функции PlatformCheck, если нажата S
    public void PlatformDown()
    {
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            GetComponent<PlatformFalling>().Start();
        }
    }
    
    
    // Вызов класса StairUpDown, если персонаж около лестницы
    public void UpDownOnStairs()
    {
        if (LayersChecker.checkStairs)
        {
            GetComponent<StairsUpDown>().UpDown();
        }
        else
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
    }
}
