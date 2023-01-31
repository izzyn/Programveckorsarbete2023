

using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

[ExecuteInEditMode]
public class InventorySetup : MonoBehaviour
{

    [SerializeField][Range(0,500f)]
    private float distanceInbetween = 100f;
    [SerializeField]
    private GameObject[] slots = new GameObject[8];
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 targetPos = slots[0].GetComponent<RectTransform>().anchoredPosition;
        targetPos.x = -1 * distanceInbetween * (((float)slots.Length + 1) / 2);
        foreach (GameObject slot in slots)
        {
            targetPos.x += distanceInbetween;
            slot.GetComponent<RectTransform>().anchoredPosition = targetPos;
            
        }
    }
}
