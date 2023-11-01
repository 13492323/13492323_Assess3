using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int num;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            EventCenter.GetInstance().EventTrigger<Item,int>("GetItem",this,num);
            Destroy(gameObject);
        }
    }
}
