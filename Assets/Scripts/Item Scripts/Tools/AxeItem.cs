

public class AxeItem : ItemUsable
{
    public AxeItem(int amount) : base(amount)
    {
        itemType = ItemType.Axe;
        SetSpriteFromName("Axe");
        SetInUseSpriteFromName("Axe");
        itemName = "Axe";
        stackSize = 1;
    }

   

}