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
        Inventory.ClearList();
        if (GameManager.dayCount > GameManager.highscore)
        {
            GameManager.highscore = GameManager.dayCount;
        }
        saveload.SavePlayer();

        GameManager.dayCount = 0;

        SceneManager.LoadScene("Menu");
    }
}
