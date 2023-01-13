using UnityEngine;

public class WoodItem: Item
{
    public WoodItem(int amount) : base( amount)
    {
        
        SetSprite(Resources.Load("Assets/Textures/Wood") as Texture2D);
    }
    
    
    
    
    
}
