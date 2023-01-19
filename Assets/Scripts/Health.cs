<<<<<<< Updated upstream

=======
using System;
>>>>>>> Stashed changes
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float HP;
<<<<<<< Updated upstream
=======
    
    public float maxHP;


    private void Start()
    {
        HP = maxHP;
    }
>>>>>>> Stashed changes

    private void Update()
    {
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void reduceHP(int amount)
    {
        HP -= amount;
    }
}
