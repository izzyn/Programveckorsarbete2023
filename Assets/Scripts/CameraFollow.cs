using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform camera;
    [SerializeField]
    private Vector2 offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        camera.position = new Vector3(transform.position.x + offset.x, transform.position.y + offset.y, camera.position.z);
    }
}
