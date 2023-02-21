using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//fredrik
public class BackKey : MonoBehaviour
{
    public GameObject OptionsMenu;
    public GameObject MainMenu;

    // Update is called once per frame
    void Update()
    {
        //if the escape key or the backspace key is pressed, it disables the options menu and enables the main menu
        if (Input.GetKeyDown(KeyCode.Backspace) || Input.GetKeyDown(KeyCode.Escape))
        {
            OptionsMenu.SetActive(false);
            MainMenu.SetActive(true);
        }
    }
}
