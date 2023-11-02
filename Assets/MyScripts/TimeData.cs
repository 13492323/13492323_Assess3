using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeData : MonoBehaviour
{
    public Text timetxt;
    void Start()
    {
       
        timetxt.text = "Time:"+PlayerPrefs.GetString("LongestTime");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
