using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public weaponSystem weaponSystem;
    public bool PlayerLeft = false;
    public bool PlayerRight = false;
    public bool PlayerUp = false;
    public bool PlayerDown = false;
    private Animator anim;
    [SerializeField, Range(0f, 100f)] 
    private float walkSpeed = 5f;

    private Rigidbody2D rigidBody;

    
    // Start is called before the first frame update
    void Start()
    {
        PlayerDown = true;
        //weaponSystem = GameObject.FindGameObjectWithTag("Player").GetComponent<weaponSystem>();
        anim = gameObject.GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
        GameManager.player = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        transform.position = new Vector3(rigidBody.position.x, rigidBody.position.y, rigidBody.position.y*0.1f - transform.localScale.y*0.1f * 0.6f);
        
        //Get what direction the player is moving in(8 directions, up down left, right and all diagonals in between)
        Vector3 moveDir = new Vector3();
        if(anim.GetBool("leftWalk")==false)
        {
            if(anim.GetBool("rightWalk") == false)
            {
                if(anim.GetBool("frontWalk") == false)
                {
                    if(anim.GetBool("Backwalk") == false)
                    {
                        anim.SetBool("Idle", true);
                        
                    }
                }
            }
        }
        if (weaponSystem.isAttacking == false)
        {
            if (Input.GetKey(KeyCode.W))
            {
                PlayerLeft = false;
                PlayerRight = false;
                PlayerUp = true;
                PlayerDown = false;

                moveDir += Vector3.up;
                anim.SetBool("Backwalk", true);
                anim.SetBool("Idle", false);
                anim.SetBool("frontWalk", false);
                anim.SetBool("leftWalk", false);
                anim.SetBool("rightWalk", false);

            }
            else
            {
                anim.SetBool("Backwalk", false);
            }
            if (Input.GetKey(KeyCode.S))
            {
                PlayerLeft = false;
                PlayerRight = false;
                PlayerUp = false;
                PlayerDown = true;

                moveDir += Vector3.down;
                anim.SetBool("frontWalk", true);
                anim.SetBool("Idle", false);
                anim.SetBool("Backwalk", false);
                anim.SetBool("leftWalk", false);
                anim.SetBool("rightWalk", false);
            }
            else
            {
                anim.SetBool("frontWalk", false);
            }
            if (Input.GetKey(KeyCode.A))
            {
                PlayerLeft = false;
                PlayerRight = true;
                PlayerUp = false;
                PlayerDown = false;
                moveDir += Vector3.left;
                anim.SetBool("leftWalk", true);
                anim.SetBool("Idle", false);
                anim.SetBool("frontWalk", false);
                anim.SetBool("Backwalk", false);
                anim.SetBool("rightWalk", false);
            }
            else
            {
                anim.SetBool("leftWalk", false);
            }
            if (Input.GetKey(KeyCode.D))
            {
                PlayerLeft = true;
                PlayerRight = false;
                PlayerUp = false;
                PlayerDown = false; moveDir += Vector3.right;
                anim.SetBool("rightWalk", true);
                anim.SetBool("Idle", false);
                anim.SetBool("frontWalk", false);
                anim.SetBool("leftWalk", false);
                anim.SetBool("Backwalk", false);
            }
            else
            {
                anim.SetBool("rightWalk", false);
            }
        }
        //Normalize moveDir so movement isn't faster during diagonal movement
        moveDir.Normalize();
        
        //Move the player to new position for it's frame
        rigidBody.MovePosition(transform.position + moveDir * (walkSpeed/200f));


    }

}
