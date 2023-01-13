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
        WoodItem woodItem = new WoodItem( 3);
        
        
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

public static class Inventory
{
    public static List<Item> inventoryList = new List<Item>();

    public static int selectedSlot;
    public static int CheckAmountOfItem(ItemType itemType)
    {
        throw new NotImplementedException();
        
    }
    public static bool DoesInventoryContain(ItemType itemType, int amount)
    {
        throw new NotImplementedException();
    }
    public static void AddItem(Item item)
    {
        inventoryList.Add(item);
    }
    
    public static void RemoveAmountOfItem(ItemType itemType, int amount)
    {
        throw new NotImplementedException();
    }

    public static bool DoesItemFit(Item item)
    {
        throw new NotImplementedException();
    }
    
    
    
}
