
    using UnityEngine;

    public class ScrapItem: Item
    {
        
        public ScrapItem(int amount) : base( amount)
        {
            name = "Scrap";
            itemType = ItemType.Scrap;
           SetSprite(Resources.Load<Sprite>("Scrap"));
        }
    }