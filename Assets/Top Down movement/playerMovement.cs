using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float movespeed = 5f;
    public Rigidbody2D rigidbody;
    public Vector2 movement;

    private void Start()
    {
    
    }

    void Update()
    {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        bool isShiftKeyDown = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        if(isShiftKeyDown)
        {
            rigidbody.MovePosition(rigidbody.position + movement * (movespeed/2) * Time.fixedDeltaTime);
        }
        else
        {
            rigidbody.MovePosition(rigidbody.position + movement * movespeed * Time.fixedDeltaTime);
        }
    }
}
