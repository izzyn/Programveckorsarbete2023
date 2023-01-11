using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    [SerializeField, Range(0f, 100f)] 
    private float walkSpeed = 5f;

    private Rigidbody2D rigidBody;

    private bool isColliding;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        transform.position = new Vector3(pos.x, pos.y, pos.y*0.1f - transform.localScale.y*0.1f);
        
        //Get what direction the player is moving in(8 directions, up down left, right and all diagonals in between)
        Vector3 moveDir = new Vector3();

        if (Input.GetKey(KeyCode.W))
        {
            moveDir += Vector3.up;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveDir += Vector3.down;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveDir += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveDir += Vector3.right;
        }
        
        //Normalize moveDir so movement isn't faster during diagonal movement
        moveDir.Normalize();
        
        //Move the player to new position for it's frame
        rigidBody.MovePosition(transform.position + moveDir * (walkSpeed/200f));
        
        
    }

}
