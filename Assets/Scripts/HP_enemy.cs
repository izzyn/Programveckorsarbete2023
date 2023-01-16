using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class HP_enemy : MonoBehaviour
{
    [SerializeField]
    public int HP;
    DMG_weapons dmg;
    Dictionary<ItemType, int> damageReferance;
    // Start is called before the first frame update
    void Start()
    {
        damageReferance = FindObjectOfType<DMG_weapons>().dmg;
    }

    // Update is called once per frame
    void Update()
    {
        

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

            

        }
    }

}

