using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class weaponSystem : MonoBehaviour
{
    public PlayerMovement playerMovement; 
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
    private float timer;
    KeyCode AttackKey = KeyCode.Mouse0;
    // Start is called before the first frame update
    void Start()
    {
        ItemStack stack = new ItemStack(Register.GetItemFromType(ItemType.Axe));
        Inventory.AddItem(stack);
        stack = new ItemStack(Register.GetItemFromType(ItemType.Spear));
        Inventory.AddItem(stack);
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
        dmg.Add(ItemType.Spear, dmg_spear);
        dmg.Add(ItemType.Axe, dmg_axe);
        anim = gameObject.GetComponent<Animator>();
      //  Inventory.AddItem(new AxeItem());
    }

    // Update is called once per frame
    void Update()
    {

        if (playerMovement.PlayerLeft == true)
        {
            anim.SetInteger("PlayerDirection", 3);
        }
        if (playerMovement.PlayerUp == true)
        {
            anim.SetInteger("PlayerDirection", 1);
        }
        if (playerMovement.PlayerDown==true)
        {
            anim.SetInteger("PlayerDirection", 4);
        }
        if (playerMovement.PlayerRight==true)
        {
            anim.SetInteger("PlayerDirection", 2);
        }
        if (Input.GetKeyDown(AttackKey))
        {
            if (timer >= 1)
            {
              
                ItemStack itemStack = Inventory.GetSelectedItemStack();
                if (itemStack == null)
                {
                 print("null return");
                return; 
                }
                

                
                Item item = itemStack.GetItem();
                SpriteRenderer.sprite = Resources.Load<Sprite>("Textures/Tools/Axe");
                if (item.GetItemType() == ItemType.Spear)
                {
                    timer = 0;
                    print("spear");
                    anim.SetInteger("WeaponID", 1);
                }
                if (item.GetItemType() == ItemType.Axe)
                {
                    timer = 0;
                    print("axe");
                    anim.SetInteger("WeaponID", 2);
                }
            }
         
        }
        if(timer <= 1)
        {
            timer += Time.deltaTime;
        }
        if(timer >= 1)
        {
            anim.SetInteger("WeaponID", 0);
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


