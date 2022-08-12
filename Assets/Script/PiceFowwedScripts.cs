using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class PiceFowwedScripts : MonoBehaviour
{
    Rigidbody2D rigit2d;
    float JumpPower = 700f;
   [SerializeField] private float moveSpeed;
   
   [SerializeField] private float jumpPower;
   
    public const int Upwalk = 0;
    public const int RightWalk = 1;
    public const int DownWalk = 2;
    public const int LeftWalk = 3;
    public int state = 2;
    private float speed = 3;
    // Update is called once per frame
    void Start()
    {
        this.rigit2d = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            this.rigit2d.AddForce(transform.up * jumpPower);
        }
        move();
        Inputkey();
        switch(state)
        {
            case Upwalk:
            {
               this.GetComponent<Animator>().SetInteger("walk", Upwalk);
               break;
            }
            case LeftWalk:
            {
                this.GetComponent<Animator>().SetInteger("walk",LeftWalk);
                break;
            }
             case RightWalk:
             {
               this.GetComponent<Animator>().SetInteger("walk",RightWalk);
                break;
             }
             case DownWalk:
             {
                this.GetComponent<Animator>().SetInteger("walk",DownWalk);
                break;
             }
                
        }
    }
    public void Inputkey() //操作キーはこちらへ　操作キーはWASDでお願いします
    { 
       if(Input.GetKey(KeyCode.W))
       {
        state = Upwalk;
        this.transform.Translate(0,speed*Time.deltaTime,0);
       }
       if(Input.GetKey(KeyCode.A))
       {
        state = LeftWalk;
        this.transform.Translate(-speed*Time.deltaTime,0,0);
       }
       if(Input.GetKey(KeyCode.S))
       {
         state = DownWalk;
         this.transform.Translate(0,-speed*Time.deltaTime,0);
       }
       if(Input.GetKey(KeyCode.D))
       {
         state = RightWalk;
         this.transform.Translate(speed*Time.deltaTime,0,0);
       }
      
    }
    public void move()
    {
       float deltaspeed = moveSpeed * Time.deltaTime;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.tag == "target")
        {
            Debug.Log("");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Target")
        {
            GetComponent<Rigidbody2D>().WakeUp();
            Debug.Log("Hit");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "target")
        {
            GetComponent<Rigidbody2D>().Sleep();
            Debug.Log("Hit");
        }
    }
}
