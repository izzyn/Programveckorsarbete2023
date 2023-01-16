using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponSystem : MonoBehaviour
{
    [SerializeField]
    private int dmg_spear;
    [SerializeField]
    private int dmg_axe;
    [SerializeField]
    public Dictionary<ItemType, int> dmg = new Dictionary<ItemType, int>();
    KeyCode AttackKey = KeyCode.Mouse0;
    // Start is called before the first frame update
    void Start()
    {
        dmg.Add(ItemType.Spear, dmg_spear);
        dmg.Add(ItemType.Axe, dmg_axe);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(AttackKey))
        {
            Item item = Inventory.GetSelectedItem();
            if(item.GetItemType()==ItemType.Spear)
            {

            }
            if (item.GetItemType() == ItemType.Axe)
            {

            }
        }
    }
}
