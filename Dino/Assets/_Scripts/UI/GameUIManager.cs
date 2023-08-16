using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    [SerializeField] GameObject score;
    [SerializeField] GameObject pauseMenu;

    Text scoreText;
    int textScore = 0;

    private static bool isPause;

    void Start()
    {
        scoreText = score.GetComponentInChildren<Text>();
        Debug.Log("Мини-обучение");
    }

    void FixedUpdate()
    {
        textScore += (int)Spawner.speed / 2;
        scoreText.text = string.Format("{0:D16}", textScore);
    }

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
            OnPauseButtonClick();
    }

    /// <summary>
    /// Pause or resume on button pause click
    /// </summary>
    public void OnPauseButtonClick()
    {
        if (isPause)
            Continue();
        else
            Pause();
    }

    /// <summary>
    /// Make pause
    /// </summary>
    private void Pause()
    {
        Time.timeScale = 0;
        isPause = true;
        pauseMenu.SetActive(true);
    }

    /// <summary>
    /// Continue game
    /// </summary>
    private void Continue()
    {
        Time.timeScale = 1;
        isPause = false;
        pauseMenu.SetActive(false);
    }
}
