using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField] LayerMask groundMask;
    [SerializeField] Transform footPos;
    [SerializeField] int jumpCount = 2;


    static readonly int jumpForce = 13;

    void Start()
   {
        rb = GetComponent<Rigidbody2D>();
   }

    void Update()
    {
        
    }

    /// <summary>
    /// Return is player on ground
    /// </summary>
    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(footPos.position, 0.2f, groundMask);
    }

    /// <summary>
    /// Return can the player jump
    /// </summary>
    public bool IsJumpEnought()
    {
        return jumpCount > 0;
    }

    /// <summary>
    /// Make player jump
    /// </summary>
    public void Jump()
    {
        jumpCount--;
        rb.velocity = new Vector2(rb.position.x, 0);
        rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            jumpCount = 2;
    }
}
