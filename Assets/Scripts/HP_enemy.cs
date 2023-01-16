using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class HP_enemy : MonoBehaviour
{
    [SerializeField]
    public int HP;
    DMG_weapons dmg;
    // Start is called before the first frame update
    void Start()
    {
        dmg = FindObjectOfType<DMG_weapons>();
    }

    // Update is called once per frame
    void Update()
    {
        if()

        if(HP<=0)
        {
            print("im ded");
            transform.position = new Vector3(0, 0, 0);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "weapon")
        {
            HP-=dmg.dmg;

        }
    }

}

