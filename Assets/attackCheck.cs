using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackCheck : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
