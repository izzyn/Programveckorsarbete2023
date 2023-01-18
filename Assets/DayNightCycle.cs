using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayNightCycle : MonoBehaviour
{
    [SerializeField]
    private bool fadeIn = false;
    [SerializeField]
    private bool fadeOut = false;
    [SerializeField]
    private CanvasGroup canvasGroup;
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
        if (fadeIn)
        {
            if (canvasGroup.alpha < 0.95f)
            {
                canvasGroup.alpha += Time.deltaTime;
                if(canvasGroup.alpha >= 0.95f)
                {
                    fadeIn = false;
                }
            }
        }

        if (fadeOut)
        {
            if (canvasGroup.alpha >= 0)
            {
                canvasGroup.alpha -= Time.deltaTime;
                if (canvasGroup.alpha == 0)
                {
                    fadeOut = false;
                }
            }
        }
    }

    void MakeDay()
    {
        Invoke("MakeNight", dayLength);

        isNight = false;

        dayCounterText.text = "day " + GameManager.dayCount;

        fadeOut = true;
    }

    void MakeNight()
    {
        Invoke("MakeDay", nightLength);

        isNight = true;

        GameManager.dayCount++;

        fadeIn = true;
    }
}
