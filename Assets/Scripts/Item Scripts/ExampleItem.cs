
using UnityEngine;

public class ExampleItem:Item
{

    public ExampleItem(int amount) : base( amount)
    {
        //Assign Item Label/ItemType/Reference type/Enum
        itemType = ItemType.Example;
        //Sets the sprite/texture of the item
        SetSprite(Resources.Load<Sprite>("Example"));
        
        //How you set an item stack size, default is 64 if none is set
        //How you add a recipe to the item
        ScrapItem scrap = new ScrapItem(1);
        WoodItem wood = new WoodItem(1);
        
        recipe.Add(scrap);
        recipe.Add(wood);
        
        //add name to item
        name = "Example Item";
    }
    

    //Overriding this method will let you make something happen when u rightclick with it in hand. (ps. there is another method for leftclick)
    public override void TriggerRightClickEvent()
    {
       
    }
}
