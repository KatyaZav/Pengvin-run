using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    [SerializeField] GameObject score;
    Text scoreText;
    int textScore = 0;

    void Start()
    {
        scoreText = score.GetComponentInChildren<Text>();
        Debug.Log("Мини-обучение");
    }

    void FixedUpdate()
    {
        textScore += (int)Spawner.speed/2;
        scoreText.text = MakeScore(textScore); 
    }

    private string MakeScore(int score)
    {
        var len = score.ToString().Length;

        int[] zero = new int[16 - len];
        string zeros = string.Join("", zero);
        zeros = string.Concat(zeros, score.ToString());
        Debug.Log(zeros);
        
        return zeros;
    }
}
