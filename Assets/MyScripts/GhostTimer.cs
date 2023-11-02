using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GhostTimer : MonoBehaviour
{
    public static GhostTimer instance;
    public GhostTimer()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            return;
        }
    }
    public Text countdownText;
    public float countdownTime = 10f;

    private void Start()
    {
      
    }
    private void OnEnable()
    {
        StartCoroutine(StartCountdown());
    }

    private IEnumerator StartCountdown()
    {
        float currentTime = countdownTime;

        while (currentTime > 0)
        {
            countdownText.text = currentTime.ToString("F0");
            yield return new WaitForSeconds(1f);
            currentTime--;
        }
        
        yield return new WaitForSeconds(1f);
       gameObject.SetActive(false);
    }

    
    
    
}
