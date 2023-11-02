using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


//面板基类
//找到自己面板下的控件
//包含ui控件的基本行为
   public class BasePanel : MonoBehaviour
   {
    //通过里式转换原则来存储所有的控件
    private Dictionary<string,List<UIBehaviour>> controlDic = new Dictionary<string, List<UIBehaviour>>();
    protected virtual void Awake()
    {
       FindChildrenControl<Button>();
       FindChildrenControl<Image>();
       FindChildrenControl<Slider>();
       FindChildrenControl<Text>();
       FindChildrenControl<ScrollRect>();
       FindChildrenControl<Toggle>();
       
    }
    //显示自己时调用
    public virtual void ShowMe()
    {
        Debug.Log(this.gameObject.name+"面板被初始化");
    }
    //隐藏自己
    public virtual void HideMe()
    {
        
    }

    protected virtual void OnClick(string btnName)
    {
        
    }
    protected virtual void OnValueChange(string toggleName,bool value)
    {
        
    }
    //得到对应控件
    protected T GetControl<T>(string controlName)where T:UIBehaviour
    {
        if (controlDic.ContainsKey(controlName))
        {
            for (int i = 0; i < controlDic[controlName].Count; ++i)
            {
                if (controlDic[controlName][i] is T)
                    //Debug.Log(controlName);
                    return controlDic[controlName][i] as T;
            }
        }
        return null;
    }
   
    /// <summary>
    /// 找到子对象的对应控件
    /// </summary>
    /// <typeparam name="T">必须是UI控件类型</typeparam>
    protected void FindChildrenControl<T>()where T:UIBehaviour
    {
        T[] controls = this.GetComponentsInChildren<T>();
        for (int i = 0; i < controls.Length; ++i)
        {
            string  objName = controls[i].gameObject.name;
            if (controlDic.ContainsKey(objName))
            {
                controlDic[objName].Add(controls[i]);
            }
            else
            {
                controlDic.Add(objName,new List<UIBehaviour>(){controls[i]});
            }
             //如果是按钮控件
            if (controls[i] is Button)
            {
             (controls[i] as Button).onClick.AddListener(()=>
             {
                OnClick(objName);
             });
            }else //如果是toggle控件
            if (controls[i] is Toggle)
            {
                (controls[i] as Toggle).onValueChanged.AddListener((value) =>
                {
                    OnValueChange(objName,value);
                });
            }
        }
        
    }
}