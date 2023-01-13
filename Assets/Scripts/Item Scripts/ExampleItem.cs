using System.Collections.Generic;
using UnityEngine;

public class ExampleItem:Item
{
    private ItemType itemType = ItemType.Example;
    //private List<Item> recipe;
    public ExampleItem(int amount) : base( amount)
    {
        SetSprite(Resources.Load("Assets/Textures/Example") as Texture2D);
        ScrapItem scrap = new ScrapItem(1);
        WoodItem wood = new WoodItem(1);
        
        recipe.Add(scrap);
        recipe.Add(wood);
    }
    

    public override void TriggerRightClickEvent()
    {
       
    }
}
