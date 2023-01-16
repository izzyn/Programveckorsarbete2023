using System;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

    public abstract class Item
    {
        public Item( int amount)
        {
            this.amount = amount;
        }

        //Self explanatory fields
        protected  String name;
        protected ItemType itemType;
        private int amount;
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
            return name;
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
        public void SetAmount(int amount) => this.amount = amount;

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
        Spear

    }
