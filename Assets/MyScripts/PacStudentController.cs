        using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacStudentController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform movePoint ;

    public LayerMask whatStopMove;
    public Animator animator;
    public bool isWalking;
    public KeyCode lastInput;

    public Transform DiePoint;
// Start is called before the first frame update
    void Start()
    {
        movePoint. parent = null;
    }
  
// Update is called once per frame
    void Update()
    {
        transform. position = Vector3. MoveTowards (transform . position, movePoint. position, moveSpeed *Time . deltaTime);
        if (GameManager.instance.startGame)
        {
             if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
        {
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
                GameManager.instance.EffectSource.clip = GameManager.instance.EffectClipList[0];
                GameManager.instance.EffectSource.Play();
                if (Input.GetAxisRaw("Horizontal") == 1f)
                {
                    lastInput = KeyCode.D;
                }
                else
                {
                    lastInput = KeyCode.A;
                }
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .2f,whatStopMove))
                {
                   animator.SetFloat("MoveX",Input.GetAxisRaw("Horizontal"));
                   animator.SetFloat("MoveY",0);
                    movePoint . position += new Vector3( Input . GetAxisRaw( "Horizontal"), 0f, 0f);
                   
                }else if (Physics2D.OverlapCircle(movePoint.position + new Vector3( 0f,Input.GetAxisRaw("Vertical"), 0f), .2f,whatStopMove))
                {
                    print(1);
                    GameManager.instance.PlayWallAudio();
                }
               
            }
            if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                GameManager.instance.EffectSource.clip = GameManager.instance.EffectClipList[0];
                GameManager.instance.EffectSource.Play();
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3( 0f,Input.GetAxisRaw("Vertical"), 0f), .2f,whatStopMove))
                {
                    if (Input.GetAxisRaw("Vertical") == 1f)
                    {
                        lastInput = KeyCode.W;
                    }
                    else
                    {
                        lastInput = KeyCode.S;
                    }
                    animator.SetFloat("MoveY",Input.GetAxisRaw("Vertical"));
                    animator.SetFloat("MoveX",0);
                    movePoint . position += new Vector3(0f, Input . GetAxisRaw("Vertical"), 0f);
                }else if (Physics2D.OverlapCircle(movePoint.position + new Vector3( 0f,Input.GetAxisRaw("Vertical"), 0f), .2f,whatStopMove))
                {
                    print(1);
                    GameManager.instance.PlayWallAudio();
                }
               
            }
        }



        }
       

    }

    public void WalkAudio()
    {
        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f || Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }

        if (isWalking)
        {
            GameManager.instance.EffectSource.clip = GameManager.instance.EffectClipList[0];
            GameManager.instance.EffectSource.Play();
        }
     
    }

    public void PlayerDie()
    {
        animator.SetBool("isDie",true);
    }
    
}
