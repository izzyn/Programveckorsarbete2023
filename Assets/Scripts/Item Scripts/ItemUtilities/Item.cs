using System;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using Object = System.Object;

public abstract class Item
    {
        public Item()
        {
            Debug.Log("Init Item: " + this);
            this.SetupItem();
            Debug.Log("Setup Register: " + this.itemName);
            Register.RegisterItem(this);
            Debug.Log("Registered: " + this.itemName);
        }


        protected abstract void SetupItem();




        //Self explanatory fields
        protected  string itemName;
        protected ItemType itemType;
        protected Sprite sprite;
        protected int stackSize = 64;
        
        

        //The is saved and used as a list of items needed to craft the item, if list is empty then the item is not craftable
        protected List<ItemStack> recipe = new List<ItemStack>();

        public int GetStackSize()
        {
            return stackSize;
        }
        public List<ItemStack> GetRecipe()
        {
            return recipe;
        }
        
        public ItemType GetItemType()
        {
            return itemType;
        }
        
        public string GetName()
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

        protected void SetSpriteFromName(string fileName)
        {
            SetSprite(Resources.Load<Sprite>("Textures/Items/" + fileName));
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
