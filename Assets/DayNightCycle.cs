using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayNightCycle : MonoBehaviour
{
    public float nightShadingDuration = 0.5f;
    [SerializeField]
    private bool fadeIn = false;
    [SerializeField]
    private bool fadeOut = false;
    [SerializeField]
    private SpriteRenderer canvasGroup;
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

    // Update is called once per frame
    void Update()
    {
        if (fadeIn)
        {
            if (canvasGroup.color.a < 0.8f)
            {
                Color color = canvasGroup.color;
                color.a += Time.deltaTime * nightShadingDuration;
                canvasGroup.color = color;
                if(canvasGroup.color.a >= 0.8f)
                {
                    Color color2 = canvasGroup.color;
                    color.a -= Time.deltaTime;
                    canvasGroup.color = color;
                    fadeIn = false;
                }
            }

            
        }

        if (fadeOut)
        {
            if (canvasGroup.color.a >= 0)
            {
                Color color = canvasGroup.color;
                color.a -= Time.deltaTime * nightShadingDuration;
                canvasGroup.color = color;
                print("Did this " + canvasGroup.color.a);
                if (Mathf.Abs(canvasGroup.color.a)  <= 0.1f)
                {
                    
                    fadeOut = false;
                }
            }
        }
    }
}
