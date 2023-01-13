using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int dayCount;


    public static Item scrap; //= new Item(ItemType.Scrap);
    public static Item wood; //= new Item(ItemType.Wood);
    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public static void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        dayCount = data.dayCount;
    }
}

public static class Inventory
{
    public static List<Item> inventoryList = new List<Item>();

    //What slot is selected in hand
    public static int selectedSlot = 0;
    
    //Input a itemType get how many of that itemtype exist in inventory
    public static int CheckAmountOfItem(ItemType itemType)
    {
        int itemAmount = 0;
        foreach (Item item in inventoryList)
        {
            if(item.GetItemType() == itemType)
            {
                itemAmount =+ item.GetAmount();
            }
        }
        return itemAmount;
        
    }
    
    //Input a itemType and amount and return a boolean (true or false) if a certain amount of a specific itemtype exists in inventory
    public static bool DoesInventoryContain(ItemType itemType, int amount)
    {
        throw new NotImplementedException();
    }
    
    //Simple add item to inventory, return if it was successful, can be unsuccessful if inventory is full
    public static bool AddItem(Item item)
    {
        if (DoesItemFit(item))
        {
            inventoryList.Add(item);
            return true;
        }

        return false;
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