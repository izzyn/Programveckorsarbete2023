using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighscoreCounter : MonoBehaviour
{
    public TextMeshProUGUI highscoreCounterText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        highscoreCounterText.text = "Highscore: " + GameManager.highscore + " Days";
    }
}
