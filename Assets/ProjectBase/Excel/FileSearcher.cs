using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.IO;

public class FileSearcher : BaseManager<FileSearcher>
{
    private List<string> filename = new List<string>();
    public void SearchFile()
    {
        string subDirectory = "Excel";
        string fileExtension = "*.csv"; // 指定要搜索的文件类型，例如 .txt 文件
        string streamingAssetsPath = Application.streamingAssetsPath;
        string searchPath = Path.Combine(streamingAssetsPath, subDirectory);

        if (Directory.Exists(searchPath))
        {
            string[] filePaths = Directory.GetFiles(searchPath, fileExtension);

            foreach (string filePath in filePaths)
            {
                string fileName = Path.GetFileName(filePath);
                filename.Add(filePath);
                Debug.Log(fileName);
            }
        }
        else
        {
            Debug.LogError("子文件夹不存在");
        }
    }
    
  
}