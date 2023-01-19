using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        print("Registering Items");
        //Example Item
        Item item = new ExampleItem();
        print("Item Name: " + item.GetName());
        //Items
        Item item2 = new WoodItem();
        print("Item Name: " + item.GetName());
        Item item3 = new StoneItem();
        print("Item Name: " + item.GetName());
        new ScrapItem();
        new BerryItem();
        
        //Tools
        new AxeItem();
        new SpearItem();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
