using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolData
{
   public GameObject fatherObj;
   public List<GameObject> poolList;

   public PoolData(GameObject obj, GameObject poolObj)
   {
      fatherObj = new GameObject(obj.name);
      fatherObj.transform.parent = poolObj.transform;
      poolList = new List<GameObject>() ;
      PushObj(obj);
   }

   public void PushObj(GameObject obj)
   {
      obj.SetActive(false);
      poolList.Add(obj);
      obj.transform.parent = fatherObj.transform;
      
   }

   public GameObject GetObj()
   {
      GameObject obj = null;
      obj = poolList[0];
      poolList.RemoveAt(0);
      obj.SetActive(true);
      obj.transform.parent = null;
      return obj;
   }
}
//缓存池模块
public class CachePoolManager : BaseManager<CachePoolManager>
{
   public Dictionary<string, PoolData> poolDic = new Dictionary<string, PoolData>();

   private GameObject poolObj;
   //取出需要使用的obj
   public GameObject GetObj(string name)
   {
      GameObject obj = null;
      if (poolDic.ContainsKey(name)&& poolDic[name].poolList.Count>0)
      {
         obj = poolDic[name].GetObj();
      }
      else
      {
         obj = GameObject.Instantiate(Resources.Load<GameObject>(name));
         obj.name = name;
      }
      return obj;
   }

   //存入暂时不用的obj
   public void PushObj(string name,GameObject obj)
   {
      if (poolObj == null)
         poolObj = new GameObject("Pool");
         
     
      if (poolDic.ContainsKey(name))
      {
         poolDic[name].PushObj(obj);
      }
      else
      {
         poolDic.Add(name, new PoolData(obj,poolObj));
         
      }
   }

   public void Clear()
   {
      poolDic.Clear();
      poolObj = null;
   }
}
