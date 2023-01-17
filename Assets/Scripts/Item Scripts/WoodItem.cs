using UnityEngine;

public class WoodItem: Item
{
    public WoodItem(int amount) : base( amount)
    {
        itemName = "Wood";
        itemType = ItemType.Wood;
        SetSpriteFromName("Wood");
    }
    
    
    
    
    
}
