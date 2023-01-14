using UnityEngine;

public class SpearItem : ItemUsable
{
    public SpearItem(int amount) : base(amount)
    {
        itemType = ItemType.Spear;
        SetSpriteFromName("Spear");
        SetInUseSpriteFromName("Spear");
        name = "Spear";
        stackSize = 1;
    }

    public override void TriggerRightClickEvent()
    {
       
    }

}
