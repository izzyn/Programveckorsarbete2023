using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AIScript : MonoBehaviour
{
    public int currentTile;
    int mapSize;
    List<int> obstacleTiles;
    private void Start()
    {
        mapSize = GameObject.Find("TerrainGenerator").GetComponent<TerrainGenerator>().GetMapSize;
        obstacleTiles = GameObject.Find("TerrainGenerator").GetComponent<TerrainGenerator>().GetWaterLoggedTiles;

    }
    //Does A*
    //Keep in mind, things like distance are calculated using an ID system for position as opposed to X and Y where X = id%the size of the map and Y = (id - x)/map size
    //The formula for Y is shortened due to integer rounding making the need to subtract the x formula redundant
    public void PathFinding()
    {
        GameObject player = GameObject.FindWithTag("Player");
        int playerPosition = SimplifyVector((Vector2)player.transform.position);
        int playerX = playerPosition % mapSize;
        int playerY = playerPosition/mapSize;
        int checkTileX; 
        int checkTileY;
        float[] targetDistance = new float[mapSize*mapSize];
        float[] enemyDistnace = new float[mapSize*mapSize];
        float[] shortTargetDistance = new float[8];
        float[] shortEnemyDistance = new float[8];
        List<int> checkTiles = new List<int>();
        checkTiles.Add(SimplifyVector((Vector2)transform.position));
        int startTileX = checkTiles[0] % mapSize;
        int startTileY = checkTiles[0] / mapSize;
        targetDistance[checkTiles[0]] = Mathf.Min(Mathf.Abs(playerX - startTileX), Mathf.Abs(playerY - startTileY)) * Mathf.Sqrt(2) + Mathf.Abs(playerX - startTileX - (playerY - startTileY));
        int currentTileIndex = 0;

        while (true)
        {
            List<int> walkableTiles = getWalkablePositions(checkTiles[currentTileIndex]);
            for(int i = 0; i < walkableTiles.Count; i++)
            {
                checkTileX = walkableTiles[i] % mapSize;
                checkTileY = walkableTiles[i] / mapSize;
                //shortTargetDistance[i] = Mathf.Min(Mathf.Abs(playerX - checkTileX), Mathf.Abs(playerY - checkTileY)) * Mathf.Sqrt(2) + Mathf.Abs(playerX - checkTileX - (playerY - checkTileY));
                Vector2 towardPlayerVector = new Vector2(playerX - checkTileX, playerY - checkTileY);
                shortTargetDistance[i] = towardPlayerVector.sqrMagnitude;
                shortEnemyDistance[i] = enemyDistnace[checkTiles[currentTileIndex]] + Mathf.Sqrt(Mathf.Abs(checkTileX - (checkTiles[currentTileIndex] % mapSize)) + Mathf.Abs(checkTileY - (checkTiles[currentTileIndex] / mapSize)));
                float sumDistance = shortEnemyDistance[i] + shortTargetDistance[i];
                if (sumDistance < targetDistance[walkableTiles[i]] + enemyDistnace[walkableTiles[i]] || targetDistance[walkableTiles[i]] + enemyDistnace[walkableTiles[i]] == 0)
                {
                    if(!checkTiles.Contains(walkableTiles[i]))
                    {
                        checkTiles.Add(walkableTiles[i]);
                    }
                    targetDistance[walkableTiles[i]] = shortTargetDistance[i];
                    enemyDistnace[walkableTiles[i]] = shortEnemyDistance[i];

                }
            }
            checkTiles.RemoveAt(currentTileIndex);

        }

    }
    public List<int> getWalkablePositions(int tile)
    {
        List<int> walkablePositions = new List<int>();
        if (!obstacleTiles.Contains(tile + mapSize))
        {
            walkablePositions.Add(tile+mapSize);
        }
        if (!obstacleTiles.Contains(tile - mapSize))
        {
            walkablePositions.Add(tile - mapSize);
        }
        if (!obstacleTiles.Contains(tile - 1))
        {
            walkablePositions.Add(tile - 1);
        }
        if (!obstacleTiles.Contains(tile + 1))
        {
            walkablePositions.Add(tile + 1);
        }
        if(!obstacleTiles.Contains(tile + 1 + mapSize) && (!obstacleTiles.Contains(tile + 1) && !obstacleTiles.Contains(tile + mapSize)))
        {
            walkablePositions.Add(tile + mapSize + 1);
        }
        if (!obstacleTiles.Contains(tile - 1 + mapSize) && (!obstacleTiles.Contains(tile - 1) && !obstacleTiles.Contains(tile + mapSize)))
        {
            walkablePositions.Add(tile + mapSize - 1);
        }
        if (!obstacleTiles.Contains(tile + 1 - mapSize) && (!obstacleTiles.Contains(tile + 1) && !obstacleTiles.Contains(tile - mapSize)))
        {
            walkablePositions.Add(tile - mapSize + 1);
        }
        if (!obstacleTiles.Contains(tile - 1 - mapSize) && (!obstacleTiles.Contains(tile - 1) && !obstacleTiles.Contains(tile - mapSize)))
        {
            walkablePositions.Add(tile - mapSize - 1);
        }
        return walkablePositions;

    }
    int SimplifyVector(Vector2 vector)
    {
        return (int)((vector.x) + (mapSize / 2)) + mapSize * (int)(-vector.y + (mapSize / 2));
    }
}
