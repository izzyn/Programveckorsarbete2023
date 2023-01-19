using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float HP;

<<<<<<< HEAD
    private void Update()
    {
        if(HP <= 0)
=======
    

    private void Update()
    {
        if (HP <= 0)
>>>>>>> 97d32022079a21f3013c0aba3facdba05ce3bb69
        {
            Destroy(gameObject);
        }
    }
<<<<<<< HEAD
    public void reduceHP(int amount)
    {
        HP -= amount;
    }
=======
>>>>>>> 97d32022079a21f3013c0aba3facdba05ce3bb69
}
