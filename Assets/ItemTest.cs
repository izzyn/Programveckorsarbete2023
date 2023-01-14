using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using UnityEngine;

[ExecuteInEditMode]
public class ItemTest : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    [SerializeField, Range(0,5)]
    private int Slider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        List<Item> items = new List<Item>();
        items.Add(new ExampleItem(10));
        items.Add(new SpearItem(10));
        items.Add(new BerryItem(10));
        items.Add(new StoneItem(10));
        items.Add(new ScrapItem(10));
        items.Add(new WoodItem(10));
        Item item = items[Slider];
        print("Item Amount: " + item.GetAmount());
        print("Recipe: ");
        if(item.GetRecipe().Count == 0) print("No Recipe");
        else
        foreach(Item rItem in item.GetRecipe())
        {
            print(rItem.GetAmount() + " " + rItem.GetName());
        }
        print(item.ToString());
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = item.GetSprite();

    }
}
