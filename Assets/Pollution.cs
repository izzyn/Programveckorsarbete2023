using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pollution : MonoBehaviour
{
    static float pollution;
    public static float GetPolution => pollution;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(pollute());   
    }
    IEnumerator pollute()
    {
        pollution = 1;
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
