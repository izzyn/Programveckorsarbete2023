using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    public int dayLength = 60;
    [SerializeField]
    public int nightLength = 90;

    public static bool isNight;
    public static Item scrap = new Item(ItemType.Scrap);
    public static Item wood = new Item(ItemType.Wood);



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
