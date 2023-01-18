using UnityEngine;

public class StoneItem:Item
{
    public StoneItem() : base()
    {
        SetSpriteFromName("Stone");
        itemType = ItemType.Stone;
        itemName = "Stone";
    }
}