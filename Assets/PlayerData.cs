using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerData
{

    public int dayCount;
    //public 'datatype (int, bool, float or string)' 'variable name';

    public PlayerData(GameManager player)
    {
        dayCount = GameManager.dayCount;
        //'variable name' = GameManager.'variable name'
    }
}