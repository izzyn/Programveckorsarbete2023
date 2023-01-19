using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreCounter : MonoBehaviour
{
    public saveload saveload;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            GameOver();
        }
    }
    public void GameOver()
    {
        if (GameManager.dayCount > GameManager.highscore)
        {
            GameManager.highscore = GameManager.dayCount;
        }
        GameManager.dayCount = 0;

        saveload.SavePlayer();

        SceneManager.LoadScene("Menu");
    }
}
