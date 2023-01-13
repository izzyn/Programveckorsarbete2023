using UnityEngine;

public class StoneItem:Item
{
    private ItemType itemType = ItemType.Example;
    
    public StoneItem(int amount) : base( amount)
    {
        //Sets the sprite/texture of the item
        SetSprite(Resources.Load<Sprite>("Stone"));

        itemType = ItemType.Stone;
        //add name to item
        name = "Stone";
    }
    

    //Overriding this method will let you make something happen when u rightclick with it in hand. (ps. there is another method for leftclick)
    public override void TriggerRightClickEvent()
    {
       
    }
}