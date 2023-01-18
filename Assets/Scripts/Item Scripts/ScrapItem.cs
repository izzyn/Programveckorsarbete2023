using UnityEngine;

public class ScrapItem: Item
{
    public ScrapItem() : base()
    {
        itemName = "Scrap";
        itemType = ItemType.Scrap;
        SetSpriteFromName("Scrap");
    }
}