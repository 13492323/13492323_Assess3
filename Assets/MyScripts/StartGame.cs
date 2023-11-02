using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public Text txt;
    void Start()
    {
    
        StartCoroutine(startGame());
    }

    IEnumerator startGame()
    { 
        yield return new WaitForSeconds(0.2f);
        txt.text = "3";
        yield return new WaitForSeconds(1);
        txt.text = "2";
        yield return new WaitForSeconds(1);
        txt.text = "1";
        yield return new WaitForSeconds(1);
        txt.text = "GO!";
        yield return new WaitForSeconds(1);
        txt.text = " ";
        GameManager.instance.startGame = true;
        GameManager.instance.BGMSource.Play();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
