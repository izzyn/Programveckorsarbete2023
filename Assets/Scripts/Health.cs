using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float HP;
    public float maxHP;


    private void Start()
    {
        HP = maxHP;
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
