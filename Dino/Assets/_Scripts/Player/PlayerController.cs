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
    [SerializeField] PlayerMoving playerMoving;

    private void Start()
    {
        if (playerMoving == null)
            playerMoving = GetComponent<PlayerMoving>();

        GameUIManager.GameStarted += OnGameStarted;
    }

    private void OnDestroy()
    {
        GameUIManager.GameStarted -= OnGameStarted;
    }

    /// <summary>
    /// Start game actions
    /// </summary>
    public void OnGameStarted()
    {
        playerMoving.SetTriggerWalk();
        StartCoroutine(GameLogicPlaying());
    }

    private IEnumerator GameLogicPlaying()
    {
        while (true)
        {
            bool canJump = playerMoving.IsGrounded() && playerMoving.IsJumpCountEnought();

            if (Input.GetButtonDown(nameJumpControlButtons.ToString())
                && canJump)
            {
                playerMoving.Jump();
            }

            if (Input.GetButton(nameSlideControlButtons.ToString()))
            {
                if (playerMoving.IsGrounded())
                    playerMoving.StartSlide();
                else
                    playerMoving.MoveDown();
            }
            if (Input.GetButtonUp(nameSlideControlButtons.ToString()))
                playerMoving.StopSlide();

            yield return new WaitForEndOfFrame();
        }
    }         

    /// <summary>
    /// Actions happends on player dead
    /// </summary>
    public void OnDead(GameObject obstacle)
    {
        Debug.Log(string.Format("{0} ��� ���� {1}", name, obstacle.name));
        Debug.LogWarning("�������� ����!");

        PlayerDead?.Invoke(name);
    }
}