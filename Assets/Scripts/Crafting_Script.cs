using System.Collections;
using System.Collections.Generic;
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
    private int stoneRequired = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            if(Inventory.CheckAmountOfItem(ItemType.Scrap)>=scrapRequired)
            {
                if (Inventory.CheckAmountOfItem(ItemType.Wood)>=woodRequired)
                {
                    if(Inventory.CheckAmountOfItem(ItemType.Stone)>=stoneRequired)
                    print("craft compleate");
                    Inventory.RemoveAmountOfItem(ItemType.Scrap, scrapRequired);
                    Inventory.RemoveAmountOfItem(ItemType.Wood, woodRequired);
                    Inventory.RemoveAmountOfItem(ItemType.Stone, stoneRequired);
                }
            }
        }
    }
}
