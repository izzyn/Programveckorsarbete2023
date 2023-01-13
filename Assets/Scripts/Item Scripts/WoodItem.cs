using UnityEngine;

public class WoodItem: Item
{
    public WoodItem(int amount) : base( amount)
    {
        name = "Wood";
     SetSprite(Resources.Load<Sprite>("Wood"));
    }
    
    
    
    
    
}
