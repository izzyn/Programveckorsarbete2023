using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class Crafting_Script : MonoBehaviour
{

    // weapons
    //spear
    //bow and arrow
    //sledgehammer
    //tools
    //axe
    //bucket
    // infrastructure
    //chest
    //wall
    private int scrapRequired =10;
    private int woodRequired = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            GameManager.scrap.SetAmount(GameManager.scrap.GetAmount + 1);
            print(GameManager.scrap.GetAmount + "scrap");
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            GameManager.wood.SetAmount(GameManager.wood.GetAmount + 1);
            print(GameManager.wood.GetAmount+"wood");
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            if(GameManager.scrap.GetAmount>=scrapRequired)
            {
                if (GameManager.wood.GetAmount>=woodRequired)
                {
                    print("craft compleate");
                    GameManager.wood.SetAmount(GameManager.wood.GetAmount -woodRequired);
                    GameManager.scrap.SetAmount(GameManager.scrap.GetAmount - scrapRequired);
                }
            }
        }
    }
}
