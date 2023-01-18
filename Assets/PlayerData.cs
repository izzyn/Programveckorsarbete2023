using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerData
{

    public int highscore;
    //public 'datatype (int, bool, float or string)' 'variable name';

    public PlayerData(GameManager player)
    {
        highscore = GameManager.highscore;

        //'variable name' = GameManager.'variable name'
    }
}