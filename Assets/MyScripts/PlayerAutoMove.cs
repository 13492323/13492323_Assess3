using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAutoMove : MonoBehaviour
{
    public static PlayerAutoMove instance;
    Vector3 startPos = new Vector3(1,-1,0);
    Vector3 targetPos;
    ForwardType pacMacForward = ForwardType.Right;
    public float speed = 10;
    public GameObject pacman;
    public PlayerAutoMove()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    private Animator animator;
    public enum ForwardType
    {
        Up,
        Down,
        Left,
        Right
    }
    void Start()
    {
        animator = GetComponent<Animator>();
        pacman.transform.position = startPos;
        targetPos = startPos + Vector3.right;
    }
    void Update()
    {
        if (!GameManager.instance.startGame)
        {
            return;
        }
        AutuMove(pacMacForward);

    }

    public void AutuMove(ForwardType forwardType)
    {
        if (!GameManager.instance.EffectSource.isPlaying)
        {
            GameManager.instance.EffectSource.clip = GameManager.instance.EffectClipList[0];
            GameManager.instance.EffectSource.volume = 0.2f;
            GameManager.instance.EffectSource.Play();
        }

        Vector3 movetowards = Vector3.MoveTowards(pacman.transform.position, targetPos, Time.deltaTime * speed);
        pacman.transform.position = movetowards;

        Vector3 lastPos = targetPos;
        if ((pacman.transform.position - targetPos).sqrMagnitude < 0.00001)
        {
            switch (forwardType)
            {
                case ForwardType.Right:
                    if (PosDown(targetPos))
                    {
                        targetPos += Vector3.down;
                    }
                    else if (PosRight(targetPos))
                    {
                        targetPos += Vector3.right;
                    }
                    break;
                case ForwardType.Down:
                    if (PosLeft(targetPos))
                    {
                        targetPos += Vector3.left;
                    }
                    else if (PosDown(targetPos))
                    {
                        targetPos += Vector3.down;
                    }
                    break;
                case ForwardType.Left:
                    if (PosUp(targetPos))
                    {
                        targetPos += Vector3.up;
                    }
                    else if (PosLeft(targetPos))
                    {
                        targetPos += Vector3.left;
                    }
                    break;
                case ForwardType.Up:
                    if (PosRight(targetPos))
                    {
                        targetPos += Vector3.right;
                    }
                      
                    else if (PosUp(targetPos))
                    {
                        targetPos += Vector3.up;
                    }
                       
                    break;
            }
           
        }
    }

    public bool PosUp(Vector3 targetPos)
    {
        pacMacForward = ForwardType.Up;
        animator.SetBool("IsUp", true);
        animator.SetBool("IsRight", false);
        animator.SetBool("IsDown", false);
        animator.SetBool("IsLeft", false);
        if (MapData.instance.levelMap[-(int)targetPos.y - 1, (int)targetPos.x] ==5 || MapData.instance.levelMap[-(int)targetPos.y - 1, (int)targetPos.x] ==6 || MapData.instance.levelMap[-(int)targetPos.y - 1, (int)targetPos.x] == 0)
        {
            
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool PosRight(Vector3 targetPos)
    {
        pacMacForward = ForwardType.Right;
        animator.SetBool("IsUp", false);
        animator.SetBool("IsRight", true);
        animator.SetBool("IsDown", false);
        animator.SetBool("IsLeft", false);
        if (MapData.instance.levelMap[-(int)targetPos.y, (int)targetPos.x + 1] == 5 || MapData.instance.levelMap[-(int)targetPos.y, (int)targetPos.x + 1] == 6 || MapData.instance.levelMap[-(int)targetPos.y, (int)targetPos.x + 1] == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool PosDown(Vector3 targetPos)
    {
        pacMacForward = ForwardType.Down;
        animator.SetBool("IsUp", false);
        animator.SetBool("IsRight", false);
        animator.SetBool("IsDown", true);
        animator.SetBool("IsLeft", false);
        if (MapData.instance.levelMap[-(int)targetPos.y + 1, (int)targetPos.x] == 5 || MapData.instance.levelMap[-(int)targetPos.y + 1, (int)targetPos.x] == 6 || MapData.instance.levelMap[-(int)targetPos.y + 1, (int)targetPos.x] == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool PosLeft(Vector3 targetPos)
    {
        pacMacForward = ForwardType.Left;
        animator.SetBool("IsUp", false);
        animator.SetBool("IsRight", false);
        animator.SetBool("IsDown", false);
        animator.SetBool("IsLeft", true);
        if (MapData.instance.levelMap[-(int)targetPos.y, (int)targetPos.x - 1] == 5 || MapData.instance.levelMap[-(int)targetPos.y, (int)targetPos.x - 1] == 6 || MapData.instance.levelMap[-(int)targetPos.y, (int)targetPos.x - 1] == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

