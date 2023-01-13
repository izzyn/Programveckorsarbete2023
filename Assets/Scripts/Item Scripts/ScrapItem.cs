
    using UnityEngine;

    public class ScrapItem: Item
    {
        
        public ScrapItem(int amount) : base( amount)
        {
            name = "Scrap";
           SetSprite(Resources.Load<Sprite>("Scrap"));
        }
    }