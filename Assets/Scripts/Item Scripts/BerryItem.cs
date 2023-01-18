using UnityEngine;

public class BerryItem:Item
{
    protected override void SetupItem()
    {
        //Sets the sprite/texture of the item
        SetSpriteFromName("Berry");
        stackSize = 16;
        itemType = ItemType.Berry;
        //add name to item
        itemName = "Berry";
        Debug.Log("Berry Item Created");
    }
}