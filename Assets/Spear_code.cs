using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spear_code : MonoBehaviour
{
    [SerializeField]
    private int dmg_Spear;

    HP_enemy enemy;
    // Start is called before the first frame update
    void Start()
    {
        enemy = FindObjectOfType<HP_enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D (Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            enemy.HP -= dmg_Spear;

        }
    }
}