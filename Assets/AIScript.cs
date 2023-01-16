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
        Vector2[] test = PathFinding();
        Debug.Log(test);

    }
    //Does A*
    //Keep in mind, things like distance are calculated using an ID system for position as opposed to X and Y where X = id%the size of the map and Y = (id - x)/map size
    //The formula for Y is shortened due to integer rounding making the need to subtract the x formula redundant
    public Vector2[] PathFinding()
    {
        List<Vector2> path = new List<Vector2>();
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
        int backwardsSearchTile = playerPosition;

        while (true)
        {
            if (checkTiles.Contains(playerPosition))
            {
                break;
            }
            List<int> walkableTiles = getWalkablePositions(checkTiles[currentTileIndex]);
                for (int i = 0; i < walkableTiles.Count; i++)
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
                        if (!checkTiles.Contains(walkableTiles[i]))
                        {
                            checkTiles.Add(walkableTiles[i]);
                        }
                        targetDistance[walkableTiles[i]] = shortTargetDistance[i];
                        enemyDistnace[walkableTiles[i]] = shortEnemyDistance[i];

                    }
                }
                int tempIndex = -1;
                float tempValue = -1;
                float tempTargetValue = -1;
                checkTiles.RemoveAt(currentTileIndex);
                for (int i = 0; i < checkTiles.Count; i++)
                {
                    if (targetDistance[checkTiles[i]] + enemyDistnace[checkTiles[i]] <= tempValue || tempValue == -1)
                    {
                        if (targetDistance[checkTiles[i]] + enemyDistnace[checkTiles[i]] == tempValue)
                        {
                            if (tempTargetValue < targetDistance[checkTiles[i]] || tempIndex == -1)
                            {
                                tempValue = targetDistance[checkTiles[i]] + enemyDistnace[checkTiles[i]];
                                tempTargetValue = targetDistance[checkTiles[i]];
                                tempIndex = i;

                            }
                        }
                        else
                        {
                            tempValue = targetDistance[checkTiles[i]] + enemyDistnace[checkTiles[i]];
                            tempTargetValue = targetDistance[checkTiles[i]];
                            tempIndex = i;

                        }
                    }
                }
            currentTileIndex = tempIndex; 
        }
        /*while (true)
        {
            List<int> walkableTiles = getWalkablePositions(backwardsSearchTile);
            int tempIndex = 0;
            float tempValue = -1;

            for (int i = 0; i < walkableTiles.Count; i++)
            {
                if (enemyDistnace[walkableTiles[i]] < tempValue || tempValue == -1 && (enemyDistnace[walkableTiles[i]] != 0 || walkableTiles[i] == SimplifyVector((Vector2)(gameObject.transform.position))))
                {
                    tempIndex = walkableTiles[i];
                    tempValue = enemyDistnace[walkableTiles[i]];
                }
            }
            path.Add(DeSimplifyVector(backwardsSearchTile) - DeSimplifyVector(tempIndex));
            if (tempIndex == SimplifyVector((Vector2)(gameObject.transform.position)))
            {
                break;
            }
            backwardsSearchTile = tempIndex;
        }
        */
        
        path.Reverse();
        return path.ToArray();

    }
    public List<int> getWalkablePositions(int tile)
    {
        List<int> walkablePositions = new List<int>();
        if (!obstacleTiles.Contains(tile + mapSize) && tile + mapSize <= mapSize*mapSize && tile + mapSize >= 0)
        {
            walkablePositions.Add(tile+mapSize);
        }
        if (!obstacleTiles.Contains(tile - mapSize) && tile - mapSize <= mapSize * mapSize && tile - mapSize >= 0)
        {
            walkablePositions.Add(tile - mapSize);
        }
        if (!obstacleTiles.Contains(tile - 1) && tile - 1 <= mapSize * mapSize && tile - 1 >= 0 && (tile-1) % mapSize != 0)
        {
            walkablePositions.Add(tile - 1);
        }
        if (!obstacleTiles.Contains(tile + 1) && tile + 1 <= mapSize * mapSize && tile + 1 >= 0 && (tile + 1) % mapSize != 0)
        {
            walkablePositions.Add(tile + 1);
        }
        if(!obstacleTiles.Contains(tile + 1 + mapSize) && (!obstacleTiles.Contains(tile + 1) && !obstacleTiles.Contains(tile + mapSize)) && tile + 1 + mapSize <= mapSize * mapSize && tile + 1 + mapSize >= 0 && (tile + 1 + mapSize) % mapSize != 0)
        {
            walkablePositions.Add(tile + mapSize + 1);
        }
        if (!obstacleTiles.Contains(tile - 1 + mapSize) && (!obstacleTiles.Contains(tile - 1) && !obstacleTiles.Contains(tile + mapSize)) && tile - 1 + mapSize <= mapSize * mapSize && tile - 1 + mapSize >= 0 && (tile - 1 + mapSize) % mapSize != 0)
        {
            walkablePositions.Add(tile + mapSize - 1);
        }
        if (!obstacleTiles.Contains(tile + 1 - mapSize) && (!obstacleTiles.Contains(tile + 1) && !obstacleTiles.Contains(tile - mapSize)) && tile + 1 - mapSize <= mapSize * mapSize && tile + 1 - mapSize >= 0 && (tile + 1 - mapSize) % mapSize != 0)
        {
            walkablePositions.Add(tile - mapSize + 1);
        }
        if (!obstacleTiles.Contains(tile - 1 - mapSize) && (!obstacleTiles.Contains(tile - 1) && !obstacleTiles.Contains(tile - mapSize)) && tile - 1 - mapSize <= mapSize * mapSize && tile - 1 - mapSize >= 0 && (tile - 1 - mapSize) % mapSize != 0)
        {
            walkablePositions.Add(tile - mapSize - 1);
        }
        return walkablePositions;

    }
    int SimplifyVector(Vector2 vector)
    {
        return (int)((vector.x) + (mapSize / 2)) + mapSize * (int)(-vector.y + (mapSize / 2));
    }
    Vector2 DeSimplifyVector(int simplifiedVector)
    {
        return new Vector2((((simplifiedVector % mapSize) - mapSize / 2)) + 0.5f, (mapSize / 2) - 0.5f - ((simplifiedVector - (simplifiedVector % mapSize)) / mapSize));
    }
}
