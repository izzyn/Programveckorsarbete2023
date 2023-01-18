using UnityEngine;

public class BerryItem:Item
{
    protected override void SetupItem()
    {
        SetSpriteFromName("Berry");
        stackSize = 16;
        itemType = ItemType.Berry;
        itemName = "Berry";
        Debug.Log("Berry Item Created");
    }
}