using UnityEngine;

public class StoneItem:Item
{
    public StoneItem(int amount) : base( amount)
    {
        SetSpriteFromName("Stone");
        itemType = ItemType.Stone;
        itemName = "Stone";
    }
}