using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class Timer : MonoBehaviour
{
    public float timeRemaining = 10;
    public Text timer, highscoreTextMenu, highscoreTextEnd, scoreText;
    public GameObject end;
    int highscore;
    
    public void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore");
        highscoreTextMenu.text = "Highscore: " + highscore;
    }

    private void Update()
    {
        if (timeRemaining > 0)
        {
            timer.text = "Time: " + timeRemaining.ToString("F0");
            timeRemaining -= Time.deltaTime;
        }
        else 
        {
            Time.timeScale = 0;
            Cursor.visible = true;
            Manager.startGame = false;

            if (Goal.points > highscore)
            {
                highscore = Goal.points;
                PlayerPrefs.SetInt("highscore", highscore);
            }

            highscoreTextEnd.text = "Highscore: " + highscore;
            highscoreTextMenu.text = "Highscore: " + highscore;
            scoreText.text = "Actual score: " + Goal.points;
            end.SetActive(true);
        }
    }
}
