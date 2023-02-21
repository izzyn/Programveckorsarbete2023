using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//fredrik
[System.Serializable]
public class PlayerData
{
    //this script contains the data to be saved by the SaveSystem script
    //the following comments tell you how to add data
    public int highscore;
    //public 'datatype (int, bool, float or string)' 'variable name';

    public PlayerData(GameManager player)
    {
        highscore = GameManager.highscore;

        //'variable name' = GameManager.'variable name'
    }
}