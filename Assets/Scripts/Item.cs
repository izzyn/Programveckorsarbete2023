using System.Collections.Generic;
using UnityEngine;

    public abstract class Item
    {
        public Item( int amount)
        {
            this.amount = amount;
        }

        protected ItemType itemType;
        private int amount;
        protected Sprite sprite;

        protected List<Item> recipe = new List<Item>();

        public Sprite GetSprite => sprite; 
        protected void SetSprite(Texture2D texture)
        {
            sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
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
        Stone
    }
