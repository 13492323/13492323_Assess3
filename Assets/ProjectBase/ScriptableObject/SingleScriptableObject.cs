using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 可作为全局唯一的配置数据的单例模式基类（注意：配置文件名字必须与类名相同）
/// </summary>
/// <typeparam name="T"></typeparam>
public class SingleScriptableObject<T>:ScriptableObject where T:ScriptableObject
{
   private static T instance;

   public static T Instance
   {
      get
      {
         if (instance==null)
         {
            //加载对应资源数据资源文件
            instance=Resources.Load<T>("ScriptableObject/" +typeof(T).Name);
         }

         if (instance==null)
         {
            instance = CreateInstance<T>();
         }
         return instance;
      }
   }
}
