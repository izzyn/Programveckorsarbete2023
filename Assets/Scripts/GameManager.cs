using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
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


    public static int dayCount = 0;

   
    public static int highscore;

    public static Item scrap; //= new Item(ItemType.Scrap);
    public static Item wood; //= new Item(ItemType.Wood);

    public static GameObject player;
}

public static class Register
{
    private static Dictionary<ItemType, Item> itemDictionary = new Dictionary<ItemType, Item>();
    public static void RegisterItem(Item item)
    {
        itemDictionary.Add(item.GetItemType(), item);
    }
    
    public static Item GetItemFromType(ItemType type)
    {
        return itemDictionary[type];
    }
}


public static class Inventory
{
   public static Item[] inventoryList = new Item[8];

    //What slot is selected in hand
    public static int selectedSlot = 0;
    
    //Input a itemType get how many of that itemtype exist in inventory
    public static int CheckAmountOfItem(ItemType itemType)
    {
        
        int itemAmount = 0;
        foreach (Item item in inventoryList)
        {
            if(item != null)
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
            if(item != null)
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
        int index = 0;
        // Debug.Log("Adding item: " + item.GetItemType() + " amount: " + amount);
        foreach (Item invItem in inventoryList)
        {

            
            if (invItem == null && amount > 0)
            {
                // Debug.Log("Adding item to slot: " + index);
                inventoryList[index] = item;
                Debug.Log(Inventory.inventoryList[index].GetItemType());
                if (amount > item.GetStackSize())
                {
                    inventoryList[index].SetAmount(item.GetStackSize());
                    amount -= item.GetStackSize();
                }
                else
                {
                    //Debug.Log("Set amount to ZERO");
                    amount = 0;
                }
                Debug.Log(Inventory.inventoryList[index].GetItemType() + "1");
            }
            else if (invItem != null && amount > 0)
                if (invItem.GetItemType() == item.GetItemType())
                {
                    Debug.Log(Inventory.inventoryList[index].GetItemType() + "2");
                    invItem.SetAmount(invItem.GetAmount() + amount);
                    if (invItem.GetAmount() > invItem.GetStackSize())
                    {
                        amount = invItem.GetAmount() - invItem.GetStackSize();
                        invItem.SetAmount(invItem.GetStackSize());
                    }
                    else
                    {
                        amount = 0;
                    }

                }
            
            if(index == 0) Debug.Log(Inventory.inventoryList[index].GetItemType() + "3");
    
            if (invItem != null)
                if (invItem.GetAmount() <= 0)
                {
                    Debug.Log("Set " + index + " to null");
                    inventoryList[index] = null;
                }
            
            if(index == 0)Debug.Log(Inventory.inventoryList[0].GetItemType() + " :   " + amount);

            
            if(amount <= 0)
            {
                break;
            }
            index++;
            
        }

        return amount;
    }
    

    //Simple remove item from inventory, return if it was successful, can be unsuccessful if inventory is empty for example
    public static bool RemoveAmountOfItem(ItemType itemType, int amount)
    {
        int index = 0;
        foreach (Item item in inventoryList)
        {
            if(item != null)
            if (item.GetItemType() == itemType)
            {
                if (amount >= item.GetStackSize())
                {
                    item.SetAmount(0);
                    amount -= item.GetStackSize();
                }
                else
                {
                    item.SetAmount(item.GetAmount() - amount);
                    amount = 0;
                }
            }
            if(item != null)
                if (item.GetAmount() <= 0)
                {
                    inventoryList[index] = null;   
                }

            index++;
        }

        return true;
    }

    
    //Check if item fits in inventory
    public static bool DoesItemFit(Item item)
    {
        int amount = item.GetAmount();
        foreach (Item invItem in inventoryList)
        {
            if(item.GetItemType() == invItem.GetItemType())
            {
               amount -= invItem.GetStackSize() - invItem.GetAmount();
            }
        }
        
        if(amount <= 0)
        {
            return true;
        }
        return false;
    }

    public static Item GetSelectedItem()
    {
        return inventoryList[selectedSlot];
    }
}