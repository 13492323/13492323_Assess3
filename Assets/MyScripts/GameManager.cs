using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public List<AudioClip> BGMClipList;
    public List<AudioClip> EffectClipList;

    public AudioSource BGMSource;
    public AudioSource EffectSource;

    public bool startGame = false;

    public GameManager()
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
    // Start is called before the first frame update
    void Start()
    {
        BGMSource.PlayOneShot(BGMClipList[0]);
        float clipLenght = BGMClipList[0].length;
        Invoke("StartGame", clipLenght);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        startGame = true;
        BGMSource.clip = BGMClipList[1];
        BGMSource.loop = true;
        BGMSource.Play();
    }
}
