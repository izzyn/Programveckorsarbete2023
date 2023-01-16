using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AIScript : MonoBehaviour
{
    public int currentTile;
    int mapSize;
    List<int> obstacleTiles;
    Vector2[] test = new Vector2[0];
    Rigidbody2D rb;
    int currentNode;
    [SerializeField]
    int speed;
    private void Start()
    {
        mapSize = GameObject.Find("TerrainGenerator").GetComponent<TerrainGenerator>().GetMapSize;
        obstacleTiles = GameObject.Find("TerrainGenerator").GetComponent<TerrainGenerator>().GetWaterLoggedTiles;
        rb = gameObject.GetComponent<Rigidbody2D>();
        test = PathFinding();

    }
    //Does A*
    //Keep in mind, things like distance are calculated using an ID system for position as opposed to X and Y where X = id%the size of the map and Y = (id - x)/map size
    //The formula for Y is shortened due to integer rounding making the need to subtract the x formula redundant
    public Vector2[] PathFinding()
    {
        float t1 = Time.realtimeSinceStartup;
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
        //xctargetDistance[checkTiles[0]] = Mathf.Min(Mathf.Abs(playerX - startTileX), Mathf.Abs(playerY - startTileY)) * Mathf.Sqrt(2) + Mathf.Abs(playerX - startTileX - (playerY - startTileY));
        targetDistance[checkTiles[0]] = new Vector2(playerX - startTileX, playerY - startTileY).magnitude;

        int currentTileIndex = 0;
        int backwardsSearchTile = playerPosition;
        int debug = currentTileIndex;

        while (true)
        {
            if (checkTiles.Contains(playerPosition))
            {
                break;
            }
            List<int> walkableTiles = getWalkablePositions(checkTiles[currentTileIndex]);
            int abc = 0;
                for (int i = 0; i < walkableTiles.Count; i++)
                {
                    checkTileX = walkableTiles[i] % mapSize;
                    checkTileY = walkableTiles[i] / mapSize;
                    //shortTargetDistance[i] = Mathf.Min(Mathf.Abs(playerX - checkTileX), Mathf.Abs(playerY - checkTileY)) * Mathf.Sqrt(2) + Mathf.Abs(playerX - checkTileX - (playerY - checkTileY));
                    Vector2 towardPlayerVector = new Vector2(playerX - checkTileX, playerY - checkTileY);
                    shortTargetDistance[i] = towardPlayerVector.magnitude;
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
                            if (tempTargetValue < targetDistance[checkTiles[i]])
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
                /*
                 
                */
            currentTileIndex = tempIndex; 
        }
        float t2 = Time.realtimeSinceStartup;

        while (true)
        {
            List<int> walkableTiles = getWalkablePositions(backwardsSearchTile);
            int tempIndex = 0;
            float tempValue = -1;
            float tempSegLength = 0;
            for (int i = 0; i < walkableTiles.Count; i++)
            {
                float segLength = Mathf.Sqrt(Mathf.Abs(walkableTiles[i] % mapSize - backwardsSearchTile % mapSize) + Mathf.Abs(walkableTiles[i] / mapSize - backwardsSearchTile / mapSize));
                float newValue = enemyDistnace[walkableTiles[i]] + segLength;
                if ((newValue < tempValue || tempValue == -1 || (newValue - tempValue < 0.01f  && new Vector2(startTileX - (walkableTiles[i] % mapSize), startTileY - (walkableTiles[i] / mapSize)).magnitude + segLength < new Vector2(startTileX - (tempIndex % mapSize), startTileY - (tempIndex / mapSize)).magnitude + tempSegLength)) && (enemyDistnace[walkableTiles[i]] != 0 || walkableTiles[i] == SimplifyVector((Vector2)(gameObject.transform.position))))
                {
                    tempIndex = walkableTiles[i];
                    tempValue = newValue;
                    tempSegLength = segLength;
                }
            }
            path.Add(DeSimplifyVector(tempIndex));
            if (tempIndex == SimplifyVector((Vector2)(gameObject.transform.position)))
            {
                break;
            }
            backwardsSearchTile = tempIndex;
        }
        float t3 = Time.realtimeSinceStartup;


        path.Reverse();
        return path.ToArray();

    }

    private void FixedUpdate()
    {
        if(test.Length > 0)
        {
            rb.AddForce((test[currentNode] - (Vector2)transform.position).normalized * Time.deltaTime * speed);
            rb.velocity *= Mathf.Pow(0.9f, Time.deltaTime);
            if (Vector2.Distance(test[currentNode], (Vector2)transform.position) < 0.2f && currentNode < test.Length - 1)
            {
                currentNode++;
            }
        }
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
