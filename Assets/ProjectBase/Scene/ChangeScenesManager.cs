using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


public class ChangeScenesManager : BaseManager<ChangeScenesManager>
{
    //同步加载
    public void LoadScene(string name,UnityAction fun)
    {
        SceneManager.LoadScene(name);
        fun();
    }
    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
    //异步加载
    public void LoadSceneAsyn(string name, UnityAction fun=null)
    {
        MonoManager.GetInstance().StartCoroutine(loadSceneAsyn(name, fun));
    }

    private IEnumerator loadSceneAsyn(string name, UnityAction fun)
    {
        AsyncOperation ao=SceneManager.LoadSceneAsync(name);
        while (!ao.isDone)
        {
            EventCenter.GetInstance().EventTrigger("UpdateProgressSlider",ao.progress);
            yield return ao.progress;
        }
        yield return ao;
        fun();
    }
}
