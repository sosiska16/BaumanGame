using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsUpDown : MonoBehaviour
{
    public float UpDownSpeed = 1.5f;
    private Rigidbody2D rb;
    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void UpDown()
    {
        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.velocity = new Vector2(rb.velocity.x, Input.GetAxis("Vertical") * UpDownSpeed);
    }
}
