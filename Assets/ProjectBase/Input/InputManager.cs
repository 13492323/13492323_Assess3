using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : BaseManager<InputManager>
{
    private bool CanInput =true;
    public InputManager()
    {
        MonoManager.GetInstance().AddUpdetaLiatenter(ThisUpdate);
    }

    //开启输入
    public void StartInput(bool isClose)
    {
        CanInput = isClose;
    }
    private void CheckKeyCode(KeyCode key)
    {
        if (Input.GetKeyDown(key))
        {
            EventCenter.GetInstance().EventTrigger("按下某键",key);
        }
        if (Input.GetKeyUp(key))
        {
            EventCenter.GetInstance().EventTrigger("抬起某键", key);
        }
    }
    private void ThisUpdate()
    {
        if(!CanInput)
            return;
        CheckKeyCode(KeyCode.W);
        CheckKeyCode(KeyCode.A);
        CheckKeyCode(KeyCode.S);
        CheckKeyCode(KeyCode.D);
        
    }
}
