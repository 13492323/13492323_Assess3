using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Events;

public class MonoManager : BaseManager<MonoManager>
{
    private MonoController controller;

    public MonoManager()
    {
        GameObject obj = new GameObject("MonoController");
        controller = obj.AddComponent<MonoController>();
    }
    public void AddUpdetaLiatenter(UnityAction fun)
    {
        controller.AddUpdetaLiatenter(fun);
    }
    
    public void RemoveUpdetaLiatenter(UnityAction fun)
    {
       controller.RemoveUpdetaLiatenter(fun);
    }

    public Coroutine StartCoroutine(IEnumerator routine)
    {
      return controller.StartCoroutine(routine);
    }

    public Coroutine StartCoroutine(string methodName, [DefaultValue("null")] object value)
    {
        return controller.StartCoroutine(methodName,value);
    }
    public Coroutine StartCoroutine(string methodName)
    {
        return controller.StartCoroutine(methodName);
    }
}
