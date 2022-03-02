using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        PMove();
        Jump();
    }

    private void PMove() // ������������ ��������� �� �����������
    {
        float moveVelocity = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveVelocity * moveSpeed, rb.velocity.y);
    }
    private void Jump() // ��������� ������ � �������� �� ����� �� �����, ���� ����������� ����� �������
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGround.onGround)
        {
            rb.AddForce(Vector2.up * jumpForce);
        }
    }
}