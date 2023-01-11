using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    bool menuOpen = false;
    [SerializeField]
    GameObject disableObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (menuOpen)
            {
                menuOpen = false;
                disableObject.SetActive(false);
                Time.timeScale = 1f;
            }
            else
            {
                menuOpen = true;
                disableObject.SetActive(true);
                Time.timeScale = 0.0f;
            }
        }
    }
    public void unPause()
    {
        menuOpen = false;
        disableObject.SetActive(false);
        Time.timeScale = 1f;
    }
}
