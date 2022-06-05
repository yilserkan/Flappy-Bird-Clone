using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighscoreManager : MonoBehaviour
{   
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text gameOverScoreText;
    [SerializeField] private TMP_Text gameOverHighScoreText;
    
    [SerializeField] private int currentScore;

    public int GetCurrentScore()
    {
        return currentScore;
    }

    private void Start() {
        currentScore = 0;
    }

    public void AddScorePoint()
    {
        currentScore++;
        scoreText.text = currentScore.ToString();
    }

    public void GameOverHandler()
    {
        if(PlayerPrefs.GetInt("HighScore") < currentScore)
        {
            PlayerPrefs.SetInt("HighScore", currentScore);
        }
        gameOverScoreText.text = currentScore.ToString();
        gameOverHighScoreText.text = $"HighScore: {PlayerPrefs.GetInt("HighScore").ToString()}" ;
    }   

}
