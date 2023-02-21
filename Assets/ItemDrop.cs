using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//fredrik
public class ItemDrop : MonoBehaviour
{
    public float despawnTime = 60;

    // Update is called once per frame
    void Update()
    {
        //counts down every second until the despawnTime variable reaches 0, then it destroys itself
        despawnTime -= 1 * Time.deltaTime;

        if(despawnTime < 0)
        {
            GameObject.Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //when the log collides with something, it checks if the thing it collided with has the tag Player, and if it does it adds to the inventory and then destroys itself
        //(no clue how it works pontus made it)
        if (collision.gameObject.CompareTag("Player"))
        {

            if (Inventory.AddItem(new ItemStack(Register.GetItemFromType(ItemType.Wood))) == 0)
                GameObject.Destroy(gameObject);
        }
    }
}
