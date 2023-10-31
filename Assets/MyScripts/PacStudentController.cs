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
// Start is called before the first frame update
    void Start()
    {
        movePoint. parent = null;
    }
  
// Update is called once per frame
    void Update()
    {
        transform. position = Vector3. MoveTowards (transform . position, movePoint. position, moveSpeed *Time . deltaTime);
        if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
        {
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
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
                   
                }
               
            }
            if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
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
                }
               
            }
        }


        WalkAudio();

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
    
}
