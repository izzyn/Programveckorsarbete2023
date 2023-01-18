

public class AxeItem : ItemUsable
{
    protected override void SetupItem()
    {
        itemType = ItemType.Axe;
        SetSpriteFromName("Axe");
        SetInUseSpriteFromName("Axe");
        itemName = "Axe";
        stackSize = 1;
    }

   

}