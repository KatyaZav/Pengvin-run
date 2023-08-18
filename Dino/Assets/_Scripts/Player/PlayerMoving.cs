using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;

    [SerializeField] LayerMask groundMask;
    [SerializeField] Transform footPos;
    [SerializeField] int jumpCount = 2;

    static readonly int jumpForce = 13;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
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
    public bool IsJumpCountEnought()
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

    /// <summary>
    /// Make player fall down
    /// </summary>
    public void MoveDown()
    {
        rb.velocity = new Vector2(rb.position.x, 0);
        rb.AddForce(new Vector2(0, -jumpForce / 2), ForceMode2D.Impulse);
    }

    private void Slide()
    {
        anim.SetBool("slide", Input.GetButton(nameSlideControlButtons.ToString()));
    }

    private void MakeRunAnimation()
    {
    }

    private void MakeIdleAnimation()
    {
    }

    private void MakeFallAnimation()
    {
    }

    private void MakeSlideAnimation()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            jumpCount = 2;
    }
}
