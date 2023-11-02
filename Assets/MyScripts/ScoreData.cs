using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreData : MonoBehaviour
{
    public Text scoretxt;
    void Start()
    {
        int score = PlayerPrefs.GetInt("HighestScore");
        scoretxt.text = "Score:"+score;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
