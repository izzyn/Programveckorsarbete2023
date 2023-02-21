using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//fredrik
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

    void Start()
    {
        MakeDay();
    }


    //MakeDay sets the variable isNight to false and updates the day counter
    void MakeDay()
    {
        Invoke("MakeNight", dayLength);

        isNight = false;

        dayCounterText.text = "day " + GameManager.dayCount;

        fadeOut = true;
    }

    //MakeDay sets the variable isNight to true and adds 1 the day counter, however the day counter does not update until the MakeDay function is called again
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
        //pontus helped me with this so im pretty confused but i think it changes the alpha of the night shading so it fades in when it turns night and fades out when it turns day
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
                if (Mathf.Abs(canvasGroup.color.a)  <= 0.1f)
                {
                    
                    fadeOut = false;
                }
            }
        }
    }
}
