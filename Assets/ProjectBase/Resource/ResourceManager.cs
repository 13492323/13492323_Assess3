using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ResourceManager : BaseManager<ResourceManager>
{
   //同步加载资源
   public T  Load<T>(string name)where T: Object
   {
      T res = Resources.Load<T>(name);
      if (res is GameObject)
      {
         return GameObject.Instantiate(res);
      }
      else
      {
         return res;
      }
   }
   //异步加载资源
   public void LoadAsync<T>(string name,UnityAction<T> callback) where T : Object
   {
      MonoManager.GetInstance().StartCoroutine(loadAsync(name,callback));
   }

   private IEnumerator loadAsync<T>(string name,UnityAction<T> callback)where T : Object
   {
     ResourceRequest r= Resources.LoadAsync<T>(name);
     yield return r;
     if (r.asset is GameObject)
     {
        callback(GameObject.Instantiate(r.asset) as T);
     }
     else
     {
        callback(r.asset as T);
     }
   }
}
