using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MonoController : MonoBehaviour
{
    private event UnityAction updateEvent;
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (updateEvent != null)
        {
            updateEvent();
        }
    }

    public void AddUpdetaLiatenter(UnityAction fun)
    {
        updateEvent += fun;
    }
    
    public void RemoveUpdetaLiatenter(UnityAction fun)
    {
        updateEvent -= fun;
    }
}
