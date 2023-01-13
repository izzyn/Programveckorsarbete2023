using UnityEngine;

    public abstract class Item
    {
        public Item(ItemType type, int amount)
        {
            this.itemType = type;
            this.amount = amount;
        }

        protected ItemType itemType;
        int amount;
        private Sprite sprite;

        public Sprite GetSprite => sprite;



        public int GetAmount => amount;
        public void SetAmount(int amount) => this.amount = amount;

        public void TriggerLeftClickEvent()
        {
            
        }
        public void TriggerRightClickEvent()
        {
            
        }
    }
    
    public enum ItemType
    {
        Scrap,
        Wood

    }
