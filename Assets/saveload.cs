using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saveload : MonoBehaviour
{
    public GameObject saveLoad;

    private void Start()
    {

    }
    public void SavePlayer()
    {
        SaveSystem.SavePlayer(saveLoad.GetComponent<GameManager>());
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        GameManager.highscore = data.highscore;
    }
}
