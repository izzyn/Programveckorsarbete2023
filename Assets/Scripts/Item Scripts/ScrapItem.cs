using UnityEngine;

public class ScrapItem: Item
{
    public ScrapItem(int amount) : base( amount)
    {
        itemName = "Scrap";
        itemType = ItemType.Scrap;
        SetSpriteFromName("Scrap");
    }
}