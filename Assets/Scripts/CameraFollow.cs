using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform camera;
    [SerializeField]
    private Vector2 offset;
    [SerializeField, Range(0.5f, 10f)]
    private float smoothTime = 2f;
    
    private Rigidbody2D playerRigidbody;

    private Vector3 cameraTarget;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    
    //Every fixed update it makes a new position where the camera should move
    void FixedUpdate()
    {
        cameraTarget = Vector3.Slerp(camera.position,
            new Vector3(playerRigidbody.position.x + offset.x, playerRigidbody.position.y + offset.y, camera.position.z),
            Time.deltaTime * smoothTime);
    }

    //Every frame it moves the camera to the new position
    private void Update()
    {
        camera.position = cameraTarget;
    }
}
