using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using UnityEngine.SceneManagement;

//fredrik
public class ScoreCounter : MonoBehaviour
{
    public saveload saveload;

    void Update()
    {
        //when the key R is pressed, the GameOver function is called
        if (Input.GetKeyDown(KeyCode.R))
        {
            GameOver();
        }
    }
    public void GameOver()
    {
        //when the GameOver function is called, the inventory is cleared, the highscore gets updated if the day count is higher,
        //the highscore is saved with the SaveLoad function, and the menu scene is loaded
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
