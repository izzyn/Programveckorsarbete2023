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
        new StoneItem(); // Inte denna
        new ScrapItem();
        new BerryItem();// Inte denna
        
        //Tools
        new AxeItem();// Inte denna
        new SpearItem();// Inte denna
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
