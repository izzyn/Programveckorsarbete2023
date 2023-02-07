using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pollution : MonoBehaviour
{
    //Skapad av Isak

    //Pollution scaling
    static float pollution;

    //Get polution method (spelled with 1 l this time)
    public static float GetPolution => pollution;
    // Start is called before the first frame update
    void Start()
    {
        //Starts the pollution increase
        StartCoroutine(pollute());   
    }
    IEnumerator pollute()
    {
        //Resets the pollution
        pollution = 1;
        
        //Polution increase over time
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            pollution += 0.1f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
