using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public int score = 0;
    public int items = 0;
    public GameObject end;

    private int highestScore = 0;

    private void Start()
    {
        highestScore = PlayerPrefs.GetInt("HighestScore", 0);

        EventCenter.GetInstance().AddEventListenter<Item, int>("GetItem", (item, points) =>
        {
            score += points;
            UpdateScoreText();
            CheckScore();
            items=items+1;
        });

        EventCenter.GetInstance().AddEventListenter<Ghost, int>("GhostDie", (ghost, points) =>
        {
            score += points;
            UpdateScoreText();
            CheckScore();
        });
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    private void Update()
    {
        CheckScore();
    }

    private void CheckScore()
    {
        
        if (items==218)
        {
            end.SetActive(true);
            EventCenter.GetInstance().EventTrigger("GameOver");
            SaveHighestScore();
            GameManager.instance.startGame = false;
            Time.timeScale = 0;
        }
    }

    public void SaveHighestScore()
    {
        Time.timeScale = 1;
        if (score > highestScore)
        {
            highestScore = score;
            PlayerPrefs.SetInt("HighestScore", highestScore);
            PlayerPrefs.Save();
        }
    }
}
