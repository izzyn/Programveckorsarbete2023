using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
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

    KeyCode AttackKey = KeyCode.Mouse0;
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
            Item item = Inventory.GetSelectedItem();
            if (item == null)
            {
                print("null return");
                return; 
            }
            dmg.TryGetValue(item.GetItemType(), out CurrentDamage);
            SpriteRenderer.sprite = ((ItemUsable)item).GetInUseSprite();
            if (item.GetItemType()==ItemType.Spear)
            {
           
            }
            if (item.GetItemType() == ItemType.Axe)
            {
                print("axe");
                anim.SetBool("axe", true);   
            }
            if(anim.GetBool("axe")==true)
            {
                anim.SetBool("axe", true);
                
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
        public void AlertObservers(string message)
    {
        if(message.Equals("axeAttack"))
        {
            anim.SetBool("axe", false);
        }
    }

}
