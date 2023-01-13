using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using UnityEngine;

[ExecuteInEditMode]
public class ItemTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ExampleItem item = new ExampleItem(10);
        print("Item Amount");
        Item sak = item;
       
    }
}
