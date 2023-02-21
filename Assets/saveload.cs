using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//fredrik
public class saveload : MonoBehaviour
{
    public GameObject saveLoad;

    private void Start()
    {
        //when the game starts it runs the LoadPlayer function
        LoadPlayer();
    }
    public void SavePlayer()
    {
        //saves the highscore using the SaveSystem script
        SaveSystem.SavePlayer(saveLoad.GetComponent<GameManager>());
    }

    public void LoadPlayer()
    {
        //gets the saved highscore from the SaveSystem script and sets the highscore to the saved highscore
        PlayerData data = SaveSystem.LoadPlayer();

        GameManager.highscore = data.highscore;
    }
}
