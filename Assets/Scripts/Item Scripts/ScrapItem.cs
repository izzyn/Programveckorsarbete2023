
    using UnityEngine;

    public class ScrapItem: Item
    {
        
        public ScrapItem(int amount) : base( amount)
        {
        
            SetSprite(Resources.Load("Assets/Textures/Scrap") as Texture2D);
        }
    }