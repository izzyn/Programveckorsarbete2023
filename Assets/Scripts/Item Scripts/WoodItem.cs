using UnityEngine;

public class WoodItem: Item
{
    protected override void SetupItem()
    {
        itemName = "Wood";
        itemType = ItemType.Wood;
        SetSpriteFromName("Wood");
    }
    
    
    
    
    
}
