using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    public float despawnTime = 60;

    // Update is called once per frame
    void Update()
    {
        despawnTime -= 1 * Time.deltaTime;

        if(despawnTime < 0)
        {
            GameObject.Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       // Inventory.AddItem(new WoodItem().SetAmount(1));
        GameObject.Destroy(gameObject);
    }
}
