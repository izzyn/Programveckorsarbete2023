
public class SledgeHammerItem : ItemUsable
{
    protected override void SetupItem()
    {
        itemType = ItemType.SledgeHammer;
        SetSpriteFromName("SledgeHammer");
        SetInUseSpriteFromName("SledgeHammer");
        itemName = "Sledge Hammer";
        stackSize = 1;
    }

   

}