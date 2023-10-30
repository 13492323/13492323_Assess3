using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public enum UI_Canves_Layer
{
    Bot,
    Mid,
    Top,
    System
}
//管理所有显示的面板
//提供显示和隐藏接口
public class UIManager : BaseManager<UIManager>
{
    public Dictionary<string, BasePanel> panelDic = new Dictionary<string, BasePanel>();
    private Transform bot;
    private Transform mid;
    private Transform top;
    private Transform system;

    //记录UI的canvas父对象
    public RectTransform mainCanvas;
    
    public UIManager()
    {
        //找到canvas
        GameObject obj=ResourceManager.GetInstance().Load<GameObject>("UI/MainCanvas");
        mainCanvas= obj.transform as RectTransform;
        GameObject.DontDestroyOnLoad(obj);
        //找到各层
        bot = mainCanvas.Find("bot");
        mid = mainCanvas.Find("mid");
        top = mainCanvas.Find("top");
        system = mainCanvas.Find("system");
        obj = ResourceManager.GetInstance().Load<GameObject>("UI/EventSystem");
        GameObject.DontDestroyOnLoad(obj);
    }
/// <summary>
/// 外部获取四个层级
/// </summary>
/// <param name="layer"></param>
/// <returns></returns>
    public Transform GetLayerFather(UI_Canves_Layer layer)
    {
        switch (layer)
        {
            case UI_Canves_Layer.Bot:
                return this.bot;
            case UI_Canves_Layer.Mid:
                return this.mid;
            case UI_Canves_Layer.Top:
                return this.top;
            case UI_Canves_Layer.System:
                return this.system;
            
        }

        return null;
    }
    /// <summary>
    /// 显示面板
    /// </summary>
    /// <param name="panelName">面板名</param>
    /// <param name="layer">显示在哪一层</param>
    /// <param name="callBack">显示面板后要做的事（回调函数）</param>
    /// <typeparam name="T">面板类型</typeparam>
    public void ShowPanel<T>(string panelName,UI_Canves_Layer layer=UI_Canves_Layer.Mid,UnityAction<T>callBack=null)where T:BasePanel
    {
        if (panelDic.ContainsKey(panelName))
        {
            //处理面板创建完成后的逻辑
            if (callBack != null)
                callBack(panelDic[panelName] as T);
            //避免面板重重复加载
            return;
        }
        //异步加载
        ResourceManager.GetInstance().LoadAsync<GameObject>("UI/" + panelName, (obj) =>
        {
            Debug.Log("生成"+obj.name);
          //把他作为Canvas的子对象
          //设置他的位置
          //找到父对象确定显示在哪一层
          Transform father = bot;
          switch (layer)
          {
              case UI_Canves_Layer.Mid:
                  father = mid;
                  break;
              case UI_Canves_Layer.Top:
                  father = top;
                  break;
              case UI_Canves_Layer.System:
                  father = system;
                  break;
          }
         //设置父亲对象
          obj.transform.SetParent(father); 
          //设置相对位置和大小
         /* obj.transform.localPosition=Vector3.zero;
          obj.transform.localScale=Vector3.one;
          (obj.transform as RectTransform).offsetMax=Vector2.zero;
          (obj.transform as RectTransform).offsetMin=Vector2.zero;*/
          
         //得到预制体身上的面板脚本
          T panel = obj.GetComponent<T>();
          //处理面板创建完成后的逻辑
          if (callBack != null)
              callBack(panel);
          if (panel != null)
          {
              panel.ShowMe();
          }
          else
          {
              Debug.Log(obj.name+"没有挂载面板脚本");
          }
         
          //把面板存起来
          panelDic.Add(panelName,panel);
        });
    }

    /// <summary>
    /// 隐藏面板
    /// </summary>
    /// <param name="panelName">面板名字</param>
    public void HidePanel(string panelName)
    {
        if (panelDic.ContainsKey(panelName))
        {
            GameObject.Destroy(panelDic[panelName].gameObject);
            panelDic.Remove(panelName);
        }
    }
/// <summary>
/// 得到某个已经显示的面板
/// </summary>
    public T GetPanel<T>(string name)where T:BasePanel
    {
        if (panelDic.ContainsKey(name))
        {
            return panelDic[name] as T;
        }
        else
        {
            Debug.Log("cant find "+name);
            return null;
        }
    }
/// <summary>
/// 给控件添加自定义事件监听
/// </summary>
/// <param name="control">控件对象</param>
/// <param name="type">事件类型</param>
/// <param name="callback">事件的相应函数</param>
public static void AddCustomEventListener(UIBehaviour control, EventTriggerType type, UnityAction<BaseEventData> callback)
{
    EventTrigger trigger = control.GetComponent<EventTrigger>();
    if (trigger==null)
    {
        trigger = control.gameObject.AddComponent<EventTrigger>();
    }
    EventTrigger.Entry entry = new EventTrigger.Entry();
    entry.eventID = type;
    entry.callback.AddListener(callback);
    trigger.triggers.Add(entry);
}
    
    
}
