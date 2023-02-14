using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//fredrik
public class HighscoreCounter : MonoBehaviour
{
    public TextMeshProUGUI highscoreCounterText;

    void Update()
    {
        //displays the highscore inbetween the text highscore: and days which resultsin the text Highscore: x days
        highscoreCounterText.text = "Highscore: " + GameManager.highscore + " Days";
    }
}
