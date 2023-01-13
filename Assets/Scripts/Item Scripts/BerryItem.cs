using UnityEngine;

public class BerryItem:Item
{
    public BerryItem(int amount) : base( amount)
    {
        //Sets the sprite/texture of the item
        SetSpriteFromName("Berry");
        stackSize = 16;
        itemType = ItemType.Berry;
        //add name to item
        name = "Berry";
    }
    

    //Overriding this method will let you make something happen when u rightclick with it in hand. (ps. there is another method for leftclick)
    public override void TriggerRightClickEvent()
    {
       
    }
}