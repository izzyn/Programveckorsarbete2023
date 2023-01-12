using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static item scrap = new item();
    public static item wood = new item();


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public class item
    {
        int amount;
        public int GetAmount => amount;
        public void SetAmount(int amount) => this.amount = amount;
    }
}
