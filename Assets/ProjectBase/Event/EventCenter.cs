using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Events;

public interface IEventInfo
{
    
}
public class EventInfo<T,K,L>:IEventInfo
{
   public UnityAction<T,K,L> actions;
   public EventInfo(UnityAction<T,K,L> action)
   {
      actions += action;
   }
}
public class EventInfo<T,K>:IEventInfo
{
   public UnityAction<T,K> actions;
   public EventInfo(UnityAction<T,K> action)
   {
      actions += action;
   }
}
public class EventInfo<T>:IEventInfo
{
   public UnityAction<T> actions;
   public EventInfo(UnityAction<T> action)
   {
      actions += action;
   }
}

public class EventInfo:IEventInfo
{
   public UnityAction actions;

   public EventInfo(UnityAction action)
   {
      actions += action;
   }
}

//事件中心
public class EventCenter : BaseManager<EventCenter>
{
   //key-事件的名字
   //value-监听这个事件的函数
   private Dictionary<string, IEventInfo> eventDic = new Dictionary<string, IEventInfo>();

   //监听传参事件
   
   public void AddEventListenter<T>(string name, UnityAction<T> action)//事件的名字，准备用来处理事件的委托函数
   {
      if (eventDic.ContainsKey(name))
      {
         (eventDic[name] as EventInfo<T>).actions += action;
      }
      else
      {
         eventDic.Add(name,new EventInfo<T>(action));
      }
   }
   public void AddEventListenter<T,K>(string name, UnityAction<T,K> action)//事件的名字，准备用来处理事件的委托函数
   {
      if (eventDic.ContainsKey(name))
      {
         (eventDic[name] as EventInfo<T,K>).actions += action;
      }
      else
      {
         eventDic.Add(name,new EventInfo<T,K>(action));
      }
   }
   public void AddEventListenter<T,K,L>(string name, UnityAction<T,K,L> action)//事件的名字，准备用来处理事件的委托函数
   {
      if (eventDic.ContainsKey(name))
      {
         (eventDic[name] as EventInfo<T,K,L>).actions += action;
      }
      else
      {
         eventDic.Add(name,new EventInfo<T,K,L>(action));
      }
   }
//监听无参事件
   public void AddEventListenter(string name, UnityAction action)//事件的名字，准备用来处理事件的委托函数
   {
      if (eventDic.ContainsKey(name))
      {
         (eventDic[name] as EventInfo).actions += action;
      }
      else
      {
         eventDic.Add(name,new EventInfo(action));
      }
   }
   //触发传参事件
   public void EventTrigger<T>(string name,T info) //哪一个名字的事件触发
   {
      if (eventDic.ContainsKey(name))
      {
         if ((eventDic[name] as EventInfo<T>).actions!=null)
         {
            (eventDic[name] as EventInfo<T>).actions.Invoke(info);
         }
         
      }
   }
   public void EventTrigger<T,K>(string name,T infoT,K infoK) //哪一个名字的事件触发
   {
      if (eventDic.ContainsKey(name))
      {
         if ((eventDic[name] as EventInfo<T,K>).actions!=null)
         {
            (eventDic[name] as EventInfo<T,K>).actions.Invoke(infoT,infoK);
         }
         
      }
   }
   public void EventTrigger<T,K,L>(string name,T infoT,K infoK,L infoL) //哪一个名字的事件触发
   {
      if (eventDic.ContainsKey(name))
      {
         if ((eventDic[name] as EventInfo<T,K,L>).actions!=null)
         {
            (eventDic[name] as EventInfo<T,K,L>).actions.Invoke(infoT,infoK,infoL);
         }
         
      }
   }
   //触发无参事件
   public void EventTrigger(string name) //哪一个名字的事件触发
   {
      if (eventDic.ContainsKey(name))
      {
         if ((eventDic[name] as EventInfo).actions!=null)
         {
            (eventDic[name] as EventInfo).actions.Invoke();
         }
         
      }
   }
   //移除传参事件
   public void RemoveEventListener<T>(string name, UnityAction<T> action)
   {
      if (eventDic.ContainsKey(name))
      {
         (eventDic[name] as EventInfo<T>).actions -= action;
      }
   }
   public void RemoveEventListener<T,K>(string name, UnityAction<T,K> action)
   {
      if (eventDic.ContainsKey(name))
      {
         (eventDic[name] as EventInfo<T,K>).actions -= action;
      }
   }
   public void RemoveEventListener<T,K,L>(string name, UnityAction<T,K,L> action)
   {
      if (eventDic.ContainsKey(name))
      {
         (eventDic[name] as EventInfo<T,K,L>).actions -= action;
      }
   }
   //移除无参事件
   public void RemoveEventListener(string name, UnityAction action)
   {
      if (eventDic.ContainsKey(name))
      {
         (eventDic[name] as EventInfo).actions -= action;
      }
   }

   public void Clear()
   {
      eventDic.Clear();
   }
}
