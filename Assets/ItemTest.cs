using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using UnityEngine;


public class ItemTest : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    public Item item;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if (item != null)
        {
            if (item.GetRecipe().Count == 0) ;
            else
                foreach (ItemStack rItem in item.GetRecipe())
                {
                   // print(rItem.GetAmount() + " " + rItem.GetName());
                }

           //print(item.ToString());
            
            spriteRenderer.sprite = item.GetSprite();
        }
        else
        { 
            GetComponent<SpriteRenderer>().sprite = null;
        }
        

    }
}
