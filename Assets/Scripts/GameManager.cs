using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    public int dayLength = 60;
    [SerializeField]
    public int nightLength = 90;

    public static bool isNight;
    public static Item scrap; //= new Item(ItemType.Scrap);
    public static Item wood; //= new Item(ItemType.Wood);
    

    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MakeDay()
    {
        isNight = false;

        Invoke("MakeNight", dayLength);
    }

    void MakeNight()
    {
        isNight = true;

        Invoke("MakeDay", nightLength);
    }

  
}

public class Inventory
{
    public List<Item> inventoryList = new List<Item>();
    
    public int CheckAmountOfItem(ItemType itemType)
    {
        throw new NotImplementedException();
        
    }
    public bool DoesInventoryContain(ItemType itemType, int amount)
    {
        throw new NotImplementedException();
    }
    public void AddItem(Item item)
    {
        inventoryList.Add(item);
    }
    
    public void RemoveAmountOfItem(ItemType itemType, int amount)
    {
        throw new NotImplementedException();
    }
    
    
    
}
