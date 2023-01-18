using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            GameManager.dayCount = 0;
            if (GameManager.dayCount > GameManager.highscore)
            {
                GameManager.highscore = GameManager.dayCount;
            }
        }
    }
}
