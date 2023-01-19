using UnityEngine;

public class ItemStack
    {
        private Item item;
        private int amount = 1;
        
        public ItemStack(Item item, int amount)
        {
            this.item = item;
            this.amount = amount;
        }
        public ItemStack(Item item)
        {
            this.item = item;
        }

        public Item GetItem() => this.item;
        public ItemStack SetItem(Item item)
        {
            this.item = item;
            return this;
        }
        public int GetAmount() => amount;
        public ItemStack SetAmount(int amount)
        { 
            this.amount = amount;
            return this;
        }

        public bool isValid()
        {
            return !(amount == 0 || item == null);
        }
    }