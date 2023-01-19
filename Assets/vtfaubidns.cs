using UnityEngine;

public class vtfaubidns : MonoBehaviour
{
    // Start is called before the first frame update
    private SpriteRenderer sprite;
    
    [SerializeField]
    private ItemType itemType;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Item item = Register.GetItemFromType(itemType);
        print(item.GetItemType());
        sprite.sprite = item.GetSprite();


    }
}
