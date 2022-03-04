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
        Jump();
        PlatformDown();
    }

    private void FixedUpdate()
    {
        PMove();
    }
    //-------------------------------------------
    private void PMove() // ������������ ��������� �� �����������
    {
        float moveVelocity = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveVelocity * moveSpeed, rb.velocity.y);
    }

    //������ ������

    public float jumpForce = 40f;
    private short jumpCount = 0;
    public float doubleJumpVelocity = 10f;

    private void Jump() // ��������� ������, ���� ����������� ����� �������
    {
        //-------------------------
        if (Input.GetKeyDown(KeyCode.Space) && IsGround.onGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
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
    
    //����� ������� PlatformCheck, ���� ������ S
    public void PlatformDown()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            GetComponent<PlatformFalling>().Start();
        }
    }
}
