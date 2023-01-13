using System.Collections.Generic;
using UnityEngine;

public class ExampleItem:Item
{
    private ItemType itemType = ItemType.Example;
    
    public ExampleItem(int amount) : base( amount)
    {
        //Sets the sprite/texture of the item
        SetSprite(Resources.Load<Sprite>("Example"));
        
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
