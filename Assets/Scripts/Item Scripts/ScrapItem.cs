using UnityEngine;

public class ScrapItem: Item
{
    protected override void SetupItem()
    {
        itemName = "Scrap";
        itemType = ItemType.Scrap;
        SetSpriteFromName("Scrap");
    }
}