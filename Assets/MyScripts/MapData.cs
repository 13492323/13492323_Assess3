using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapData : MonoBehaviour
{
    public static MapData instance;
    public int[,] levelMap ={
    {1,2,2,2,2,2,2,2,2,2,2,2,2,7},
    {2,5,5,5,5,5,5,5,5,5,5,5,5,4},
    {2,6,3,4,4,3,5,3,4,4,4,3,5,4},
    {2,5,4,0,0,4,5,4,0,0,0,4,5,4},
    {2,5,3,4,4,3,5,3,4,4,4,3,5,3},
    {2,5,5,5,5,5,5,5,5,5,5,5,5,5},
    {2,5,3,4,4,3,5,3,3,5,3,4,4,4},
    {2,5,3,4,4,3,5,4,4,5,3,4,4,3},
    {2,5,5,5,5,5,5,4,4,5,5,5,5,4},
    {1,2,2,2,2,1,5,4,3,4,4,3,0,4},
    {0,0,0,0,0,2,5,4,3,4,4,3,0,3},
    {0,0,0,0,0,2,5,4,4,0,0,0,0,0},
    {0,0,0,0,0,2,5,4,4,0,3,4,4,0},
    {2,2,2,2,2,1,5,3,3,0,4,0,0,0},
    {2,0,0,0,0,0,5,0,0,0,4,0,0,0},
    };
    public MapData()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            return;
        }
    }
    private void Awake()
    {
        #region µØÍ¼²¹È«
        int[,] levelMapAll = new int[levelMap.GetLength(0) * 2 - 1, levelMap.GetLength(1) * 2];
        for (int i = 0; i < levelMapAll.GetLength(0); i++)
        {
            for (int j = 0; j < levelMapAll.GetLength(1); j++)
            {
                if (i < levelMap.GetLength(0))
                {
                    if (j < levelMap.GetLength(1))
                    {
                        levelMapAll[i, j] = levelMap[i, j];
                    }
                    else
                    {
                        Debug.Log(i + "   " + (levelMapAll.GetLength(1) - j));
                        levelMapAll[i, j] = levelMap[i, levelMapAll.GetLength(1) - j - 1];
                    }
                }
                else
                {
                    levelMapAll[i, j] = levelMapAll[levelMapAll.GetLength(0) - i - 1, j];
                }
            }
        }
        levelMap = levelMapAll;
        #endregion
    }
}
