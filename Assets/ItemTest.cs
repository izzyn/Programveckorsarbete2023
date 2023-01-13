using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using UnityEngine;

[ExecuteInEditMode]
public class ItemTest : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ExampleItem item = new ExampleItem(10);
        print("Item Amount: " + item.GetAmount());
        print("Recipe: ");
        foreach(Item rItem in item.GetRecipe())
        {
            print(rItem.GetAmount() + " " + rItem.GetName());
        }
        print(item.ToString());
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = item.GetSprite();

    }
}
