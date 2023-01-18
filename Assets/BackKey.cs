using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackKey : MonoBehaviour
{
    public GameObject OptionsMenu;
    public GameObject MainMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace) || Input.GetKeyDown(KeyCode.Escape))
        {
            OptionsMenu.SetActive(false);
            MainMenu.SetActive(true);
        }
    }
}
