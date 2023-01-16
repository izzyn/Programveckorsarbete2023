using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayNightCycle : MonoBehaviour
{
    public Text dayCounterText;
    public int dayLength = 60;
    public int nightLength = 90;
    public bool isNight = false;
    public GameObject nightShading;
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

        dayCounterText.text = "day " + GameManager.dayCount;

        nightShading.SetActive(false);
    }

    void MakeNight()
    {
        Invoke("MakeDay", nightLength);

        isNight = true;

        GameManager.dayCount++;

        nightShading.SetActive(true);
    }
}
