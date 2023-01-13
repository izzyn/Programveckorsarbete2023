using UnityEngine;

public class SpearItem : Item
{
    public SpearItem(int amount) : base(amount)
    {
        itemType = ItemType.Spear;
        SetSprite(Resources.Load<Sprite>("Spear"));
        name = "Spear";
        stackSize = 1;
    }

    public override void TriggerRightClickEvent()
    {
       
    }

}
