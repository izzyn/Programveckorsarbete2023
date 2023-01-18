using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InventoryTest : MonoBehaviour
{
    
    public ItemTest[] item = new ItemTest[8];
    // Start is called before the first frame update
    void Awake()
    {
        
        Debug.Log("Started Inv Test s");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            for (int i = 0; i < 8; i++)
            {
                Inventory.inventoryList[i] = null;

            }
            return;
        }
        
        if (Input.GetKeyDown(KeyCode.G))
        {
            for (int i = 0; i < 8; i++)
            {
                Debug.Log(Inventory.inventoryList[i].GetName());
            }
            return;
        }
        
        if (Input.GetKeyDown(KeyCode.L))
        {
           AddWood(5);
           print("Added 5 wood");
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            RemoveWood(3);
            print("Removed 3 wood");
        }

        for (int i = 0; i < 8; i++)
        {
            item[i].item = Inventory.inventoryList[i];
        }
        
        
        if(Inventory.inventoryList[0] != null && Inventory.inventoryList[1] != null)
        {
            Debug.Log(Inventory.inventoryList[0].GetAmount());
            Debug.Log(Inventory.inventoryList[1].GetAmount());
        }
        
    }

    public void AddWood(int amount)
    {
        WoodItem wood = new WoodItem(amount);
        Inventory.AddItem(wood);
    }
    
    public void RemoveWood(int amount)
    {
        
        Inventory.RemoveAmountOfItem(ItemType.Wood, amount);
    }
}