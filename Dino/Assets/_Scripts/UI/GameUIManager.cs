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

    Text scoreTextUI;

    public static Action GameStarted;
    private static bool isPause;

    void Start()
    {
        scoreTextUI = score.GetComponentInChildren<Text>();

        Debug.Log("Прогрузить рекорд");
    }

    /// <summary>
    /// Load scene with name sceneName
    /// </summary>
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    /// <summary>
    /// Make game get started
    /// </summary>
    public void StartGame()
    {
        Debug.Log("Попытка запустить рекламу на все окно");
        Debug.Log("Свернуть окно меню");
        Debug.Log("Развернуть ui игры");

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
            textScore += (int)Spawner.Speed / 2;
            scoreTextUI.text = string.Format("{0:D16}", (int)textScore);

            yield return new WaitForEndOfFrame();
        }
    }
}
