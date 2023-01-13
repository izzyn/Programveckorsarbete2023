using UnityEngine;

public class SpearItem : Item
{
    public SpearItem(int amount) : base(amount)
    {

        SetSprite(Resources.Load("Assets/Textures/Spear") as Texture2D);
    }

    public override void TriggerRightClickEvent()
    {
       
    }

}
