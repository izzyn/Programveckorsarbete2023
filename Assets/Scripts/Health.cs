
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float HP;

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
