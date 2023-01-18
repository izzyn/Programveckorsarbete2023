using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        print("Registering Items");
        //Example Item
        new ExampleItem();
        
        //Items
        new WoodItem();
        new StoneItem();
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
