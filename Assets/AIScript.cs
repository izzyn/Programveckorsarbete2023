using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIScript : MonoBehaviour
{
    public void PathFinding()
    {
        float[] targetDistance = new float[(int)Mathf.Pow(GameObject.Find("TerrainGenerator").GetComponent<TerrainGenerator>().GetMapSize, 2)];
        float[] enemyDistnace = new float[(int)Mathf.Pow(GameObject.Find("TerrainGenerator").GetComponent<TerrainGenerator>().GetMapSize, 2)];
        List<int> checkTiles = new List<int>();

    }
}
