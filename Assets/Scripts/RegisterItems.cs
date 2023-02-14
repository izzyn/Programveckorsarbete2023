using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class RegisterItems
{
    static bool hasExecuted = false;

    public static void RegisterAllItems()
    {
        if (!hasExecuted)
        {
            Debug.Log("Registering Items");
            //Example Item
            new ExampleItem();
            //Items
            new WoodItem();
            new StoneItem();
            new ScrapItem();
            new BerryItem();


            //ToolsS
            new AxeItem();
            new SpearItem();
            hasExecuted = true;
        }
    }
}
