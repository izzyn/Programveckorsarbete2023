using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryObject : MonoBehaviour
{
    [SerializeField] 
    private GameObject[] slots = new GameObject[8];
    
    private SpriteRenderer[] slotSprites = new SpriteRenderer[8];

    private Color defaultColor;

    private TextMeshProUGUI[] textList = new TextMeshProUGUI[8];
    // Start is called before the first frame update
    void Start()
    {
        defaultColor = slots[0].GetComponent<SpriteRenderer>().color;
        
        for (int i = 0; i < slots.Length; i++)
        {
            slotSprites[i] = slots[i].GetComponentsInChildren<SpriteRenderer>()[1];
            textList[i] = slots[i].GetComponentInChildren<TextMeshProUGUI>();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < slots.Length; i++)
        {
            if(Inventory.inventoryList[i] != null)
            slotSprites[i].sprite = Inventory.inventoryList[i].GetItem().GetSprite();
            else
            {
                slotSprites[i].sprite = null;
            }
            
        }
        
        if(Input.mouseScrollDelta.y > 0)
        {
            Inventory.selectedSlot++;
            if(Inventory.selectedSlot > 7)
            {
                Inventory.selectedSlot = 0;
            }
            
            for(int i = 0; i < slots.Length; i++)
            {
                if(i == Inventory.selectedSlot)
                {
                    slots[i].GetComponent<SpriteRenderer>().color = Color.white;
                }
                else
                {
                    slots[i].GetComponent<SpriteRenderer>().color = defaultColor;
                }
            }
        }
        if(Input.mouseScrollDelta.y < 0)
        {
            Inventory.selectedSlot--;
            if(Inventory.selectedSlot < 0)
            {
                Inventory.selectedSlot = 7;
            }
            for(int i = 0; i < slots.Length; i++)
            {
                if(i == Inventory.selectedSlot)
                {
                    slots[i].GetComponent<SpriteRenderer>().color = Color.white;
                }
                else
                {
                    slots[i].GetComponent<SpriteRenderer>().color = defaultColor;
                }
            }
        }
        for(int i = 0; i < slots.Length; i++)
        {
           if(Inventory.inventoryList[i] != null)
           {
               if(Inventory.inventoryList[i].GetAmount() != 0)
               textList[i].text = Inventory.inventoryList[i].GetAmount().ToString();
               else textList[i].text = "";
           }
           else
           {
               textList[i].text = "";
           }
            
        }
    }
}
