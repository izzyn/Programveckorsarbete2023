using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int dayCount;

    public static GameObject player;
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
   private static Item[] inventoryList = new Item[8];

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
        foreach (Item item in inventoryList)
        {
            if(item.GetItemType() == itemType)
            {
                amount -= item.GetAmount();
            }
        }
        
        if(amount <= 0)
        {
            return true;
        }
        return false;
    }
    
    //Simple add item to inventory, returns amount of items that could not be added or got left over
    public static int AddItem(Item item)
    {
        int amount = item.GetAmount();
        if (DoesItemFit(item))
        {
            foreach (Item invIitem in inventoryList)
            {
                if(invIitem.GetItemType() == item.GetItemType())
                {
                    invIitem.SetAmount(invIitem.GetAmount() + amount);
                    if(invIitem.GetAmount() > invIitem.GetStackSize())
                    { 
                        amount = invIitem.GetAmount() - invIitem.GetStackSize();
                        invIitem.SetAmount(invIitem.GetStackSize());
                    }
                    
                }
            }
            
        }

        return amount;
    }
    
    //Simple remove item from inventory, return if it was successful, can be unsuccessful if inventory is empty for example
    public static bool RemoveAmountOfItem(ItemType itemType, int amount)
    {
        throw new NotImplementedException();
    }

    
    //Check if item fits in inventory
    public static bool DoesItemFit(Item item)
    {
        int amount = item.GetAmount();
        foreach (Item invItem in inventoryList)
        {
            if(item.GetItemType() == invItem.GetItemType())
            {
               
            }
        }
        
        if(amount <= 0)
        {
            return true;
        }
        return false;
        return true;
    }
}