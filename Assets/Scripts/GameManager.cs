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

    public void MakeDay()
    {
        isNight = false;

        Invoke("MakeNight", dayLength);
    }

    void MakeNight()
    {
        isNight = true;

        Invoke("MakeDay", nightLength);
    }

    public class item
    {
        int amount;
        public int GetAmount => amount;
        public void SetAmount(int amount) => this.amount = amount;
    }
}
