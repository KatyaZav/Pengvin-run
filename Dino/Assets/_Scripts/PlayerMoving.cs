using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    [SerializeField] string nameControlButtons;
    Rigidbody2D rb;
    Animator anim;
    public bool isGrounded = false;
    private bool lastGround = false;
    public static float jumpForce = 12;

    public LayerMask groundMask;
    public Transform footPos;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();           
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(footPos.position, 0.2f, groundMask);
        
        if (isGrounded)
        {
            Fall();
            if (Input.GetButtonDown(nameControlButtons.ToString())){
                Jump();
            }
        }

        lastGround = isGrounded;
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.position.x, 0);
        rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
    }

    private void Fall()
    {
        //if (!lastGround && isGrounded)
          //  anim.SetTrigger("jump");
    }
}
