using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUIManager : MonoBehaviour
{
    [SerializeField] GameObject score;
    [SerializeField] GameObject pauseMenu;

    [SerializeField] GameObject GameUI;
    [SerializeField] GameObject MenuUI;

    Text scoreTextUI;

    public static Action GameStarted;
    private bool isPause;    

    void Start()
    {
        scoreTextUI = score.GetComponentInChildren<Text>();
        ChangeUIMenu(false);

        Debug.Log("Прогрузить рекорд");
    }

    /// <summary>
    /// Save game progress and leave game
    /// </summary>
    public void SaveAndExit()
    {
        Debug.Log("Save");

        ChangeScene(SceneManager.GetActiveScene().name);
    }

    /// <summary>
    /// Change UI on game started or finish
    /// </summary>
    private void ChangeUIMenu(bool isGameStarted)
    {
        GameUI.SetActive(isGameStarted);
        MenuUI.SetActive(!isGameStarted);
    }

    /// <summary>
    /// Load scene with name sceneName
    /// </summary>
    public void ChangeScene(string sceneName)
    {
        Continue();
        SceneManager.LoadScene(sceneName);
    }

    /// <summary>
    /// Make game get started
    /// </summary>
    public void StartGame()
    {
        Debug.Log("Попытка запустить рекламу на все окно");
        ChangeUIMenu(true);

        Debug.Log("Мини-обучение");

        if (scoreTextUI != null)
            StartCoroutine(ScoreTextResult());
        else throw new Exception("Score Text UI is empty");

        StartCoroutine(ButtonExcepted());
        GameStarted?.Invoke();
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


    /// <summary>
    /// Pause buttons excepted
    /// </summary>
    IEnumerator ButtonExcepted()
    {
        while (true)
        {
            if (Input.GetButtonDown("Cancel"))
                OnPauseButtonClick();

            yield return new WaitForSeconds(1);
        }
    }

    /// <summary>
    /// Show and update score text ui
    /// </summary>
    IEnumerator ScoreTextResult()
    {
        float textScore = 0;

        while (true)
        {
            if (!isPause)
            {
                textScore += (int)Spawner.Speed / 2;
                scoreTextUI.text = string.Format("{0:D16}", (int)textScore);

            }
            yield return new WaitForEndOfFrame();
        }
    }
}
