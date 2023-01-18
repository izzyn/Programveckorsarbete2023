

public class SpearItem : ItemUsable
{
    protected override void SetupItem()
    {
        itemType = ItemType.Spear;
        SetSpriteFromName("Spear");
        SetInUseSpriteFromName("Spear");
        itemName = "Spear";
        stackSize = 1;
    }

   

}
