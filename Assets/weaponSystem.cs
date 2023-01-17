using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class weaponSystem : MonoBehaviour
{
    private Animator anim;
    SpriteRenderer SpriteRenderer;
    private int CurrentDamage;
    [SerializeField]
    private int dmg_spear= 1;
    [SerializeField]
    private int dmg_axe =1;
    [SerializeField]
    public Dictionary<ItemType, int> dmg = new Dictionary<ItemType, int>();

    KeyCode AttackKey = KeyCode.Space;
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        dmg.Add(ItemType.Spear, dmg_spear);
        dmg.Add(ItemType.Axe, dmg_axe);
        anim = gameObject.GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
       

        if(Input.GetKeyDown(AttackKey))
        {
            print("test 1");
            Item item = Inventory.GetSelectedItem();
            print("test 2");
            item = new AxeItem(1);
            print("test 3");
            if (item.GetItemType() == null)
            {
                print("test retuen");
                return; 
            }
            print("test 4");
            dmg.TryGetValue(item.GetItemType(), out CurrentDamage);
            print("test 5");
            SpriteRenderer.sprite = ((ItemUsable)item).GetInUseSprite();
            print("test 6");
            if (item.GetItemType()==ItemType.Spear)
            {
           
            }
            if (item.GetItemType() == ItemType.Axe)
            {
                print("axe");
                anim.SetInteger("WeaponID",0);
                anim.SetBool("axe",true);
                anim.SetBool("axe", false);
            }

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Health HP = collision.gameObject.GetComponent<Health>();
            HP.HP -= CurrentDamage;
        }
        else
        {
            return;
        }
    }
}
