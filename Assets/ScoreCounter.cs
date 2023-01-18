using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreCounter : MonoBehaviour
{
    public saveload saveload;
    public PlayGame playGame;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (GameManager.dayCount > GameManager.highscore)
            {
                GameManager.highscore = GameManager.dayCount;
            }
            GameManager.dayCount = 0;

            saveload.SavePlayer();

            SceneManager.LoadScene(playGame.sceneToLoad);
        }
    }
}
