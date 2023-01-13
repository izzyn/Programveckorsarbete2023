using UnityEngine;

public class ItemUsable:Item
{
    public ItemUsable(int amount) : base( amount)
    {
   
    }

    protected Sprite inUseSprite;
    
    protected void SetInUseSprite(Sprite sprite)
    {
        if (sprite == null)
        {
            Debug.Log("Texture error: " + this.GetName());
            this.sprite = Resources.Load<Sprite>("Error");
        }
        else 
            inUseSprite = sprite;
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
