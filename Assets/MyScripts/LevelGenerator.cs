using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public List<GameObject> spriteList = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        //清空所有手动布局地图
        for(int i = 0; i < this.transform.childCount; i++)
        {
            Destroy(this.transform.GetChild(i).gameObject);
        }
        CreateMap(MapData.instance.levelMap);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #region 地图生成部分
    public void CreateMap(int[,] LevelMap)
    {
        for (int i = 0; i < MapData.instance.levelMap.GetLength(0); i++)
        {
            for (int j = 0; j < MapData.instance.levelMap.GetLength(1); j++)
            {
                Vector3 nowPos = new Vector3(j, -i, 0);
                switch (MapData.instance.levelMap[i, j])
                {
                    case 1:
                        CornerSpriteRotate(nowPos, 1, 2);
                        break;
                    case 2:
                        SideSpriteRotate(nowPos, 1, 2);
                        break;
                    case 3:
                        CornerSpriteRotate(nowPos, 3, 4);
                        break;
                    case 4:
                        SideSpriteRotate(nowPos, 3, 4);
                        break;
                    case 5:
                        GameObject spriteTemp = Instantiate(spriteList[5], this.transform);
                        spriteTemp.transform.position = nowPos;
                        break;
                    case 6:
                        GameObject spriteTemp2 = Instantiate(spriteList[6], this.transform);
                        spriteTemp2.transform.position = nowPos;
                        break;
                    case 7:
                        TSpriteRotate(nowPos);
                        break;
                }
            }
        }

    }
    /// <summary>
    /// sprite生成且符合地图逻辑方法(需要贴图为拐点，且0角度时形状为 ┌)
    /// </summary>
    /// <param name="nowPos"> 当前点的位置</param>
    /// <param name="num_1"> 当前点的种类 </param>
    /// <param name="num_2"> 边的种类</param>
    private void CornerSpriteRotate(Vector3 nowPos, int num_1, int num_2)
    {
        //生成1 在nowPos;
        GameObject spriteTemp = Instantiate(spriteList[num_1], this.transform);
        spriteTemp.transform.position = nowPos;
        int rotate_0_priority, rotate_90_priority, rotate_180_priority, rotate_270_priority;
        rotate_0_priority = PosDown(nowPos, num_1, num_2) + PosRight(nowPos, num_1, num_2);
        rotate_90_priority = PosRight(nowPos, num_1, num_2) + PosUp(nowPos, num_1, num_2);
        rotate_180_priority = PosUp(nowPos, num_1, num_2) + PosLeft(nowPos, num_1, num_2);
        rotate_270_priority = PosLeft(nowPos, num_1, num_2) + PosDown(nowPos, num_1, num_2);
        int[] priorityList = new int[] { rotate_0_priority, rotate_90_priority, rotate_180_priority, rotate_270_priority };
        if (rotate_0_priority == Mathf.Max(priorityList))
        {
            spriteTemp.transform.Rotate(new Vector3(0, 0, 0), Space.World);
            return;
        }
        if (rotate_90_priority == Mathf.Max(priorityList))
        {
            spriteTemp.transform.Rotate(new Vector3(0, 0, 90), Space.World);
            return;
        }
        if (rotate_180_priority == Mathf.Max(priorityList))
        {
            spriteTemp.transform.Rotate(new Vector3(0, 0, 180), Space.World);
            return;
        }
        if (rotate_270_priority == Mathf.Max(priorityList))
        {
            spriteTemp.transform.Rotate(new Vector3(0, 0, 270), Space.World);
            return;
        }
        //if ((PosRight(nowPos) == num_1 || PosRight(nowPos) == num_2) && (PosDown(nowPos) == num_1 || PosDown(nowPos) == num_2))
        //{
        //    //旋转0；
        //    spriteTemp.transform.Rotate(new Vector3(0, 0, 0), Space.World);
        //    return;
        //}
        //if ((PosRight(nowPos) == num_1 || PosRight(nowPos) == num_2) && (PosUp(nowPos) == num_1 || PosUp(nowPos) == num_2))
        //{
        //    // 旋转90；
        //    spriteTemp.transform.Rotate(new Vector3(0, 0, 90), Space.World);
        //    return;
        //}
        //if ((PosLeft(nowPos) == num_1 || PosLeft(nowPos) == num_2) && (PosUp(nowPos) == num_1 || PosUp(nowPos) == num_2))
        //{
        //    spriteTemp.transform.Rotate(new Vector3(0, 0, 180), Space.World);
        //    return;
        //    //旋转180；
        //}
        //if ((PosLeft(nowPos) == num_1 || PosLeft(nowPos) == num_2) && (PosDown(nowPos) == num_1 || PosDown(nowPos) == num_2))
        //{
        //    spriteTemp.transform.Rotate(new Vector3(0, 0, 270), Space.World);
        //    return;
        //    //旋转270；
        //}
    }

    private void SideSpriteRotate(Vector3 nowPos, int num_1, int num_2)
    {
        //生成1 在nowPos;
        GameObject spriteTemp = Instantiate(spriteList[num_2], this.transform);
        spriteTemp.transform.position = nowPos;
        int rotate_0_priority, rotate_90_priority;
        rotate_0_priority = PosLeft(nowPos, num_1, num_2) + PosRight(nowPos, num_1, num_2);
        rotate_90_priority = PosUp(nowPos, num_1, num_2) + PosDown(nowPos, num_1, num_2);
        int[] priorityList = new int[] { rotate_0_priority, rotate_90_priority };
        if (rotate_0_priority == Mathf.Max(priorityList))
        {
            spriteTemp.transform.Rotate(new Vector3(0, 0, 0), Space.World);
            return;
        }
        if (rotate_90_priority == Mathf.Max(priorityList))
        {
            spriteTemp.transform.Rotate(new Vector3(0, 0, 90), Space.World);
            return;
        }
    }

    private void TSpriteRotate(Vector3 nowPos)
    {
        //生成1 在nowPos;
        GameObject spriteTemp = Instantiate(spriteList[7], this.transform);
        spriteTemp.transform.position = nowPos;
        if ((PosLeft(nowPos) == 1 || PosLeft(nowPos) == 2))
        {
            if ((PosUp(nowPos) == 3 || PosUp(nowPos) == 4))
            {
                spriteTemp.transform.Rotate(new Vector3(0, 0, 0), Space.World);
                spriteTemp.transform.localScale = new Vector3(1, -1, 1);
                return;
            }
            else if ((PosDown(nowPos) == 3 || PosDown(nowPos) == 4))
            {
                spriteTemp.transform.Rotate(new Vector3(0, 0, 0), Space.World);
                return;
            }
        }
        if ((PosDown(nowPos) == 1 || PosDown(nowPos) == 2))
        {
            if ((PosRight(nowPos) == 3 || PosRight(nowPos) == 4))
            {
                spriteTemp.transform.Rotate(new Vector3(0, 0, 90), Space.World);
                spriteTemp.transform.localScale = new Vector3(1, -1, 1);
                return;
            }
            else if ((PosLeft(nowPos) == 3 || PosLeft(nowPos) == 4))
            {
                spriteTemp.transform.Rotate(new Vector3(0, 0, 90), Space.World);
                return;
            }
        }
        if ((PosRight(nowPos) == 1 || PosRight(nowPos) == 2))
        {
            if ((PosDown(nowPos) == 3 || PosDown(nowPos) == 4))
            {
                spriteTemp.transform.Rotate(new Vector3(0, 0, 180), Space.World);
                spriteTemp.transform.localScale = new Vector3(1, -1, 1);
                return;
            }
            else if ((PosUp(nowPos) == 3 || PosUp(nowPos) == 4))
            {
                spriteTemp.transform.Rotate(new Vector3(0, 0, 180), Space.World);
                return;
            }
        }
        if ((PosUp(nowPos) == 1 || PosUp(nowPos) == 2))
        {
            if ((PosRight(nowPos) == 3 || PosRight(nowPos) == 4))
            {
                spriteTemp.transform.Rotate(new Vector3(0, 0, 270), Space.World);
                spriteTemp.transform.localScale = new Vector3(1, -1, 1);
                return;
            }
            else if ((PosLeft(nowPos) == 3 || PosLeft(nowPos) == 4))
            {
                spriteTemp.transform.Rotate(new Vector3(0, 0, 270), Space.World);
                return;
            }
        }
    }
    #endregion
    #region 人物移动计算
    public int PosUp(Vector3 targetPos)
    {
        if (-(int)targetPos.y - 1 >= 0)
        {
            return MapData.instance.levelMap[-(int)targetPos.y - 1, (int)targetPos.x];
        }
        else
        {
            return -1;
        }

    }
    public int PosRight(Vector3 targetPos)
    {
        if ((int)targetPos.x + 1 < MapData.instance.levelMap.GetLength(1))
        {
            return MapData.instance.levelMap[-(int)targetPos.y, (int)targetPos.x + 1];
        }
        else
        {
            return -1;
        }

    }
    public int PosDown(Vector3 targetPos)
    {
        if (-(int)targetPos.y + 1 < MapData.instance.levelMap.GetLength(0))
        {
            return MapData.instance.levelMap[-(int)targetPos.y + 1, (int)targetPos.x];
        }
        else
        {
            return -1;
        }

    }
    public int PosLeft(Vector3 targetPos)
    {
        if ((int)targetPos.x - 1 >= 0)
        {
            return MapData.instance.levelMap[-(int)targetPos.y, (int)targetPos.x - 1];
        }
        else
        {
            return -1;
        }

    }
    #endregion
    #region 地图生成优先级计算
    public int PosUp(Vector3 targetPos, int num_1, int num_2, int lenght = 0)
    {
        if (-(int)targetPos.y - 1 >= 0)
        {
            //如果是边
            if (MapData.instance.levelMap[-(int)targetPos.y - 1, (int)targetPos.x] == num_2)
            {
                lenght += 1;
                //边长度+1 且继续向该方向探索。
                return 1 + PosUp(targetPos + Vector3.up, num_1, num_2, lenght);
            }
            //如果是顶点
            else if (MapData.instance.levelMap[-(int)targetPos.y - 1, (int)targetPos.x] == num_1 || MapData.instance.levelMap[-(int)targetPos.y - 1, (int)targetPos.x] == 7)
            {
                if (lenght > 0)
                {
                    //如果是边+顶点可以100%确认连通
                    return 100;
                }
                else
                {
                    //如果只有顶点
                    return 1;
                }
            }
            else
            {
                //如果不是边且不是顶点 。100%不连通
                return -100;
            }
        }
        else
        {
            //下标越界
            return 0;
        }

    }
    public int PosRight(Vector3 targetPos, int num_1, int num_2, int lenght = 0)
    {
        if ((int)targetPos.x + 1 < MapData.instance.levelMap.GetLength(1))
        {
            //如果是边
            if (MapData.instance.levelMap[-(int)targetPos.y, (int)targetPos.x + 1] == num_2)
            {
                lenght += 1;
                //边长度+1 且继续向该方向探索。
                return 1 + PosRight(targetPos + Vector3.right, num_1, num_2, lenght);
            }
            //如果是顶点
            else if (MapData.instance.levelMap[-(int)targetPos.y, (int)targetPos.x + 1] == num_1 || MapData.instance.levelMap[-(int)targetPos.y, (int)targetPos.x + 1] == 7)
            {
                if (lenght > 0)
                {
                    //如果是边+顶点可以100%确认连通
                    return 100;
                }
                else
                {
                    //如果只有顶点
                    return 1;
                }
            }
            else
            {
                //如果不是边且不是顶点 。100%不连通
                return -100;
            }
        }
        else
        {
            //下标越界
            return 0;
        }

    }
    public int PosDown(Vector3 targetPos, int num_1, int num_2, int lenght = 0)
    {
        if (-(int)targetPos.y + 1 < MapData.instance.levelMap.GetLength(0))
        {
            //如果是边
            if (MapData.instance.levelMap[-(int)targetPos.y + 1, (int)targetPos.x] == num_2)
            {
                lenght += 1;
                //边长度+1 且继续向该方向探索。
                return 1 + PosDown(targetPos + Vector3.down, num_1, num_2, lenght);
            }
            //如果是顶点
            else if (MapData.instance.levelMap[-(int)targetPos.y + 1, (int)targetPos.x] == num_1 || MapData.instance.levelMap[-(int)targetPos.y + 1, (int)targetPos.x] == 7)
            {
                if (lenght > 0)
                {
                    //如果是边+顶点可以100%确认连通
                    return 100;
                }
                else
                {
                    //如果只有顶点
                    return 1;
                }
            }
            else
            {
                //如果不是边且不是顶点 。100%不连通
                return -100;
            }
        }
        else
        {
            //下标越界
            return 0;
        }

    }
    public int PosLeft(Vector3 targetPos, int num_1, int num_2, int lenght = 0)
    {
        if ((int)targetPos.x - 1 >= 0)
        {
            //如果是边
            if (MapData.instance.levelMap[-(int)targetPos.y, (int)targetPos.x - 1] == num_2)
            {
                lenght += 1;
                //边长度+1 且继续向该方向探索。
                return 1 + PosLeft(targetPos + Vector3.left, num_1, num_2, lenght);
            }
            //如果是顶点
            else if (MapData.instance.levelMap[-(int)targetPos.y, (int)targetPos.x - 1] == num_1 || MapData.instance.levelMap[-(int)targetPos.y, (int)targetPos.x - 1] == 7)
            {
                if (lenght > 0)
                {
                    //如果是边+顶点可以100%确认连通
                    return 100;
                }
                else
                {
                    //如果只有顶点
                    return 1;
                }
            }
            else
            {
                //如果不是边且不是顶点 。100%不连通
                return -100;
            }
        }
        else
        {
            //下标越界
            return 0;
        }

    }
    #endregion 
}
