using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    public Text timerText;
    private float timer = 0f;
    private string longestTime = "00:00:00";

    private void Start()
    {
        StartCoroutine(StartTimer());
        EventCenter.GetInstance().AddEventListenter("GameOver", () =>
        {
            StopCoroutine(StartTimer());
            SaveLongestTime();
        });
    }

    private IEnumerator StartTimer()
    {
        while (!GameManager.instance.startGame)
        {
            yield return null;
        }

        while (true)
        {
            timer += Time.deltaTime;
            UpdateTimerText();
            yield return null;
        }
    }

    private void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(timer / 60f);
        int seconds = Mathf.FloorToInt(timer % 60f);
        int milliseconds = Mathf.FloorToInt((timer * 100f) % 100f);
        string timeString = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
        timerText.text = timeString;
    }

    private void SaveLongestTime()
    {
        string savedTime = PlayerPrefs.GetString("LongestTime", "00:00:00");

        if (string.Compare(timerText.text, savedTime) > 0)
        {
            longestTime = timerText.text;
            PlayerPrefs.SetString("LongestTime", longestTime);
            PlayerPrefs.Save();
        }
    }
    
}
