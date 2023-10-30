using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public static class CSVToolkit 
{
   public static void LoadFile(string path, Action<List<string[]>>a)
   {
      if (!File.Exists(path))
      {
         Debug.LogError(path+"no found");
         return;
      }

      StreamReader sr = null;
      try
      {
         sr = File.OpenText(path);
         List<string[]> contene = new List<string[]>();
         string line;
         while ((line = sr.ReadLine()) != null)
         {
            contene.Add(line.Split(","));
         }

         sr.Close();
         sr.Dispose();
         a?.Invoke(contene);
      }
      catch (Exception ex)
      {
         Debug.LogError(ex.Message);
      }
   }
   
}
