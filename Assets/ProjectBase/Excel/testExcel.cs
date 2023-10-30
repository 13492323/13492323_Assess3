using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testExcel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Reader.GetInstance().ReadTableCell(0, 1);
        Reader.GetInstance().ReadRaw(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
