using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Pontus
//Fredrik
public class Health : MonoBehaviour
{
    public float HP;
    public float maxHP;


    private void Start()
    {
        HP = maxHP;

        float timer = 0;
        
        //Varje frame
        timer += Time.deltaTime;
    }


    private void Update()
    {
        if (HP <= 0)
        {
            print("Diede ");
            Destroy(gameObject);
        }
    }
    public void reduceHP(int amount)
    {
        HP -= amount;
    }
}
