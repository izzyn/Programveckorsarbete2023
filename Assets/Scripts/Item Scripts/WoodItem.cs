using UnityEngine;

public class WoodItem: Item
{
    public WoodItem(int amount) : base( amount)
    {
        name = "Wood";
        itemType = ItemType.Wood;
        SetSpriteFromName("Wood");
    }
    
    
    
    
    
}
