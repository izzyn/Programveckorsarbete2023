using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Pontus
public class GameStartScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        print("Registering Items");
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
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
