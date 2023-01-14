using System;
using UnityEngine;

public class ItemUsable:Item
{
    public ItemUsable(int amount) : base( amount)
    {
   
    }

    protected Sprite inUseSprite;
    
    protected void SetInUseSprite(Sprite sprite)
    {
        try
        {
            inUseSprite = sprite;
        }
        catch (NullReferenceException e)
        {
            Console.WriteLine("Texture error: " + this.GetName());
            
            this.sprite = Resources.Load<Sprite>("Error");
        }
    }
    
    public void SetInUseSpriteFromName(string name)
    {
        Sprite sprite = Resources.Load<Sprite>("Textures/Tools/" + name);
        SetInUseSprite(sprite);
    }

    public Sprite GetInUseSprite()
    {
        return inUseSprite;
    }

}
