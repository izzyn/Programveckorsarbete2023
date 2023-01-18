using System;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using Object = System.Object;

public abstract class Item
    {
        public Item()
        {
            
            
        }

        //Self explanatory fields
        protected  String itemName;
        protected ItemType itemType;
        private int amount = 1;
        protected Sprite sprite;
        protected int stackSize = 64;
        
        

        //The is saved and used as a list of items needed to craft the item, if list is empty then the item is not craftable
        protected List<Item> recipe = new List<Item>();

        public int GetStackSize()
        {
            return stackSize;
        }
        public List<Item> GetRecipe()
        {
            return recipe;
        }
        
        public ItemType GetItemType()
        {
            return itemType;
        }
        
        public String GetName()
        {
            return itemName;
        }

        public Sprite GetSprite() => sprite; 
        protected void SetSprite(Sprite sprite)
        {

            try
            {
                Console.WriteLine("Sprite set to " + sprite.name);
                this.sprite = sprite;
                
            }
            catch (NullReferenceException e)
            {
                this.sprite = Resources.Load<Sprite>("Error");
            }
                



        }

        protected void SetSpriteFromName(String fileName)
        {
            SetSprite(Resources.Load<Sprite>("Textures/Items/" + fileName));
        }



        public int GetAmount() => amount;
        public Item SetAmount(int amount)
        { 
            this.amount = amount;
            return this;
        }

        public virtual void TriggerLeftClickEvent()
        {
            
        }

        public virtual void TriggerRightClickEvent()
        {
            
        }
    }
    
    public enum ItemType
    {
        Example,
        Scrap,
        Wood,
        Stone,
        Berry,
        Spear,
        Axe

    }
