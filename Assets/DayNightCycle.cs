using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public int dayCount = 0;
    public int dayLength = 60;
    public int nightLength = 90;
    public bool isNight = false;
    // Start is called before the first frame update
    void Start()
    {
        MakeDay();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MakeDay()
    {
        Invoke("MakeNight", dayLength);

        isNight = false;
        dayCount++;
    }

    void MakeNight()
    {
        Invoke("MakeDay", nightLength);

        isNight = true;
    }

}
