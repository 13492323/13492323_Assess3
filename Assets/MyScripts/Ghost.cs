using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public Animator anim;

    private void Start()
    {
        
    }

    public void Die()
    {
        anim.SetBool("isDie",true);
        Invoke("des",5f);
        EventCenter.GetInstance().EventTrigger<Ghost,int>("GhostDie",this,300);
    }

    public void des()
    {
        anim.SetBool("isDie",false);
        anim.SetBool("Walk",true);
    }

    public void Scared()
    {
        GhostTimer.instance.gameObject.SetActive(true);
        GameManager.instance.BGMSource.clip = GameManager.instance.BGMClipList[2];
        GameManager.instance.BGMSource.Play();
        anim.SetBool("Scared",true);
    }
}
