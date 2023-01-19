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
    [SerializeField]
    private int timer;
    KeyCode AttackKey = KeyCode.Mouse0;
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        dmg.Add(ItemType.Spear, dmg_spear);
        dmg.Add(ItemType.Axe, dmg_axe);
        anim = gameObject.GetComponent<Animator>();
      //  Inventory.AddItem(new AxeItem());
    }

    // Update is called once per frame
    void Update()
    {
        timer= timer-1;

        if(Input.GetKeyDown(AttackKey))
        {
            timer = 80;
            Item item = Inventory.GetSelectedItem();
            //if (item == null)
            //{
               // print("null return");
                //return; 
            //}
            dmg.TryGetValue(ItemType.Axe, out CurrentDamage);
            SpriteRenderer.sprite = Resources.Load<Sprite>("Textures/Tools/Axe");
            if (ItemType.Axe == ItemType.Spear)
            {
           
            }
            if (ItemType.Axe == ItemType.Axe)
            {

                print("axe");
                anim.SetBool("axe", true);   
            }
           if(timer <= 0)
            {
                anim.SetBool("axe", false);
            }
        }
    }
    public void AlertObservers(string message)
    {
        if (message.Equals("axeAttack"))
        {
            anim.SetBool("axe", false);
        }
    }
        private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Health HP = collision.gameObject.GetComponent<Health>();
            HP.HP -= CurrentDamage;
            print(HP.HP);   
        }
        else
        {
            return;
        }
        
    }
        
    }


