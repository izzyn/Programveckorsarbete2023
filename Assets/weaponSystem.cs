using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class weaponSystem : MonoBehaviour
{
    //variables
    //markus script
    public bool IsAxe = false;
    public PlayerMovement playerMovement; 
    private Animator anim;
    SpriteRenderer SpriteRenderer;
    private int CurrentDamage=1;
    [SerializeField]
    private float timer;
    KeyCode AttackKey = KeyCode.Mouse0;
    public bool isAttacking =false;
    // Start is called before the first frame update
    void Start()
    {
        //pontus script
        ItemStack stack = new ItemStack(Register.GetItemFromType(ItemType.Axe));
        Inventory.AddItem(stack);
        stack = new ItemStack(Register.GetItemFromType(ItemType.Spear));
        Inventory.AddItem(stack);
        //pontus script
        stack = new ItemStack(Register.GetItemFromType(ItemType.SledgeHammer));
        Inventory.AddItem(stack);
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
        
        //markus script
        anim = gameObject.GetComponent<Animator>();
      //  Inventory.AddItem(new AxeItem());
    }

    // Update is called once per frame
    void Update()
    {
        //markus script
        //weapon cooldown timer
        if(timer <= 1)
        {
            timer += Time.deltaTime;
        }
        if (timer >= 1)
        {
            anim.SetInteger("WeaponID", 0);
            anim.SetBool("attacking", false);
            
        }
        if(timer>=1)
        {
            IsAxe = false;
            isAttacking = false;
        }
        //markus script
        //animation controls public
        if (anim.GetBool("attacking")==true)
        {
            isAttacking = true;
        }
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
       //attack trigger
       //markus script
        if (Input.GetKeyDown(AttackKey))
        {
            //markus script
            //attack cooldown
            if (timer >= 1)
            {
                
              //item=null failsafe
                ItemStack itemStack = Inventory.GetSelectedItemStack();
                if (itemStack == null)
                {
                 print("null return");
                return; 
                }

                anim.SetBool("attacking", true);
                //markus script
                //select weapon to play animation
                Item item = itemStack.GetItem();
                SpriteRenderer.sprite = Resources.Load<Sprite>("Textures/Tools/Axe");
                if (item.GetItemType() == ItemType.Spear)
                {
                    //markus script
                    //spear animation+cooldown
                    CurrentDamage = 1;
                    timer = 0.68f;
                    print("spear");
                    anim.SetInteger("WeaponID", 1);
                    IsAxe = false;
                }
                if (item.GetItemType() == ItemType.Axe)
                {
                    //markus script
                    //axe animation+cooldown
                  CurrentDamage = 1;
                    timer = 0.5f;
                    print("axe");
                    anim.SetInteger("WeaponID", 2);
                    IsAxe = true;
                }
                if(item.GetItemType()==ItemType.SledgeHammer)
                {
                    //markus script
                    //hammer animaton+cooldown
                 CurrentDamage = 3;
                    timer = 0;
                    print("hammer");
                    anim.SetInteger("WeaponID", 3);
                    IsAxe = false;
                }
            }
         
        }
      
        
        
    }
   
        private void OnTriggerEnter2D(Collider2D collision)
    {
        //dmg enemy
        //isaks script
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


