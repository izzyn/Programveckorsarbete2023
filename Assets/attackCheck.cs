using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackCheck : MonoBehaviour
{
    //Isak's kod

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Checks if the collision is a player
        if(collision.gameObject.tag == "Player")
        {
            //Self explanatory
            PlayerHealth.reduceHp(1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
