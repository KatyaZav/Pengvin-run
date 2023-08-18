using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    new public string name = "Player 1";
    
    [SerializeField] string nameJumpControlButtons;
    [SerializeField] string nameSlideControlButtons;

    public static Action<string> PlayerDead;
      
    /// <summary>
    /// Start game actions
    /// </summary>
    public void OnGameStarted()
    {
        StartCoroutine(GameLogicPlaying());
    }

    private IEnumerator GameLogicPlaying()
    {
        while (true)
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

            yield return new WaitForEndOfFrame();
        }
    }

    private void Slide()
    {
        anim.SetBool("slide", Input.GetButton(nameSlideControlButtons.ToString()));
    }
        

    /// <summary>
    /// Actions happends on player dead
    /// </summary>
    public void OnDead(GameObject obstacle)
    {
        Debug.Log(string.Format("{0} был убит {1}", name, obstacle.name));
        Debug.LogWarning("Добавить звук!");

        PlayerDead?.Invoke(name);
    }
}
