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
        Debug.Log("����-��������");
    }

    void FixedUpdate()
    {
        textScore += (int)Spawner.speed / 2;
        scoreText.text = MakeScore(textScore);
    }

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
            OnPauseButtonClick();
    }

    /// <summary>
    /// Make score format 0000XXX
    /// </summary>
    private string MakeScore(int score)
    {
        var len = score.ToString().Length;

        int[] zero = new int[16 - len];
        string zeros = string.Join("", zero);
        zeros = string.Concat(zeros, score.ToString());
        
        return zeros;
    }

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
