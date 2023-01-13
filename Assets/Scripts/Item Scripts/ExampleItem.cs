using UnityEngine;

public class ExampleItem:Item
{
    public ExampleItem(int amount) : base( amount)
    {
        
        SetSprite(Resources.Load("Assets/Textures/Example") as Texture2D);
    }
    
}
