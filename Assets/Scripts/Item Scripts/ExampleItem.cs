
using UnityEngine;

public class ExampleItem:Item //Replace ExampleItem with the name of your item + the word Item(for less confusion)

{

    public ExampleItem() //Replace "ExampleItem" with the same name + the word Item as the one above.
    {
        //Assign Item Label/ItemType/Reference type/Enum
        itemType = ItemType.Example;
        
        //Sets the sprite/texture of the item(Have to be placed in) ---- or a better way is to use option bellow
        SetSprite(Resources.Load<Sprite>("Textures/Items/Example"));
        
        //A better way to do it is to use this method
        SetSpriteFromName("Example"); // <<<This will automatically go to the path/folder for item textures (Assets/Reources/Textures/Items/)
                                                            // and select+ load the sprite just with a file/asset name
        
        //How you set an item stack size, default is 64 if none is set
        stackSize = 8;
        
        //How you add a recipe to the item
        ScrapItem scrap = (ScrapItem)new ScrapItem().SetAmount(10);
        WoodItem wood = new WoodItem();
        
        recipe.Add(scrap);
        recipe.Add(wood);
        
        //add a display name to item
        itemName = "Example Item";
    }
    

    //Overriding this method will let you make something happen when u rightclick with it in hand. (ps. there is another method for leftclick under it)
    public override void TriggerRightClickEvent()
    {
       
    }

    public override void TriggerLeftClickEvent()
    {
        
    }
}
