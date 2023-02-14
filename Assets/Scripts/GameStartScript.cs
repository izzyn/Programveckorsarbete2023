using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Pontus
public class GameStartScript : MonoBehaviour
{
    bool hasExecuted = false;
    // Start is called before the first frame update
    void Awake()
    {
        RegisterItems.RegisterAllItems();
        
       
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
