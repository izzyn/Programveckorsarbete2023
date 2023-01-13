using UnityEngine;

public class StoneItem:Item
{
    private ItemType itemType = ItemType.Example;
    
    public StoneItem(int amount) : base( amount)
    {
        SetSpriteFromName("Stone");

        itemType = ItemType.Stone;
        name = "Stone";
    }
}