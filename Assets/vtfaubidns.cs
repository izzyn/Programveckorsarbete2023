using UnityEngine;

public class vtfaubidns : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Item item = Register.GetItemFromType(ItemType.Example);
        print(item.GetItemType());
        
        
    }
}
