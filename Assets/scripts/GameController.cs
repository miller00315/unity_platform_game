using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public int totalScore;

    public static GameController instance;

    public Text scoreText;
    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void UpdateScore(int value)
    {
        totalScore += value;

        UpdateScoreText();
    }

    public void UpdateScoreText()
    {
        scoreText.text = totalScore.ToString();
    }
}
