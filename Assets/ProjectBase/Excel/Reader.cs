using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class Reader : BaseManager<Reader>
{
   
    

    public string ReadTableCell(int rawnum, int listnum)
    {
        List<string> Readdata = new List<string>();
        CSVToolkit.LoadFile(Application.streamingAssetsPath+"/Excel/对话表.csv", a =>
        {
            var row = a[rawnum];
            for (int i = 0; i < row.Length; i++)
            {
                Readdata.Add(row[i]);
            }
        });
        Debug.Log(Readdata[listnum]);
        return Readdata[listnum];
    }
    public List<string> ReadRaw(int rawnum)
    {
        List<string> Readdata = new List<string>();
        CSVToolkit.LoadFile(Application.streamingAssetsPath+"/Excel/对话表.csv", a =>
        {
            var row = a[rawnum];
            for (int i = 0; i < row.Length; i++)
            {
                Readdata.Add(row[i]);
            }
        });
        foreach (var item in Readdata)
        {
            Debug.Log(item);
        }
        return Readdata;
    }
}
