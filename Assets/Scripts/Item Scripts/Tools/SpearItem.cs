

public class SpearItem : ItemUsable
{
    public SpearItem(int amount) : base(amount)
    {
        itemType = ItemType.Spear;
        SetSpriteFromName("Spear");
        SetInUseSpriteFromName("Spear");
        itemName = "Spear";
        stackSize = 1;
    }

   

}
