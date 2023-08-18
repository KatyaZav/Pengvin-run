using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    new public string name = "Player 1";
    
    [SerializeField] string nameJumpControlButtons;
    [SerializeField] string nameSlideControlButtons;

      
    Animator anim;
    public bool isGrounded = false;
    public static float jumpForce = 13;
    
   public bool isRun = true;

    public static Action<string> PlayerDead;

    void Start()
    {
        anim = GetComponent<Animator>();

        anim.SetBool("idle", !isRun);
    }

    void Update()
    {
        if (isRun)
        {
            if (isGrounded)
            {
                OnFalledOnGround();
                Slide();
            }

            if (Input.GetButtonDown(nameJumpControlButtons.ToString())
                && (isGrounded || jumpCount > 0)
                && !Input.GetButton(nameSlideControlButtons.ToString()))
            {
                Jump();
            }

            if (Input.GetButton(nameSlideControlButtons.ToString()) && !isGrounded)
            {
                Fall();
            }
        }
    }

    private void Fall()
    {
        rb.velocity = new Vector2(rb.position.x, 0);
        rb.AddForce(new Vector2(0, -jumpForce/2), ForceMode2D.Impulse);
    }

    private void Slide()
    {
        anim.SetBool("slide", Input.GetButton(nameSlideControlButtons.ToString()));
    }
        

    public void Dead(GameObject obstacle)
    {
        Debug.Log(string.Format("{0} был убит {1}", name, obstacle.name));
        Debug.LogWarning("Добавить звук!");

        PlayerDead?.Invoke(name);
    }
}
