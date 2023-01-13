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

        //The is saved and used as a list of items needed to craft the item, if list is empty then the item is not craftable
        protected List<Item> recipe = new List<Item>();
        
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
            if(sprite != null) this.sprite = sprite;
            else
            {
                Debug.Log("Texture error: " + this.GetName());
                this.sprite = Resources.Load<Sprite>("Error");
            }
            
            
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
