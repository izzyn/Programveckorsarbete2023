using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Threading;

public class AIScript : MonoBehaviour
{
    //Isak's kod
    private Animator animator;
    public int currentTile;
    int mapSize;
    List<int> obstacleTiles;
    Vector2[] test = new Vector2[0];
    Rigidbody2D rb;
    int currentNode;
    [SerializeField]
    int speed;
    bool good = true;
    bool onCooldown = false;
    [SerializeField]
    GameObject attackCollider;
    bool pathStarted;
    [SerializeField]
    float distanceStart;
    IEnumerator pathUpdate;
    private void Start()
    {
        //Gets all the necessary referances for the rest of the script to work
        animator = GetComponent<Animator>();
        mapSize = GameObject.Find("TerrainGenerator").GetComponent<TerrainGenerator>().GetMapSize;
        obstacleTiles = GameObject.Find("TerrainGenerator").GetComponent<TerrainGenerator>().GetWaterLoggedTiles;
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    //Updates the path upon the player moving every n seconds
    IEnumerator updatePath()
    {
        int tempPos = 0;
        while (true)
        {
            int playerPos = SimplifyVector(GameManager.player.transform.position);
            if(tempPos != playerPos)
            {
                //Does multithreading using .Net magic
                int thisPosition = SimplifyVector(gameObject.transform.position);
                Thread thread = new Thread(() => PathFinding(playerPos, thisPosition));
                thread.Start();
            }
            tempPos = playerPos;
            yield return new WaitForSeconds(2f);
        }

    }
    //Does A*
    //Keep in mind, things like distance are calculated using an ID system for position as opposed to X and Y where X = id%the size of the map and Y = (id - x)/map size
    //The formula for Y is shortened due to integer rounding making the need to subtract the x formula redundant
    public void PathFinding(int target, int origin)
    {
        //Current place in the path (global variable because of multithreading)
        currentNode = 0;
        test = new Vector2[0];
        List<Vector2> path = new List<Vector2>();
        int playerPosition = target;
        int playerX = playerPosition % mapSize;
        int playerY = playerPosition/mapSize;
        int checkTileX; 
        int checkTileY;
        float[] targetDistance = new float[mapSize*mapSize];
        float[] enemyDistnace = new float[mapSize*mapSize];
        float[] shortTargetDistance = new float[8];
        float[] shortEnemyDistance = new float[8];
        List<int> checkTiles = new List<int>();
        checkTiles.Add(origin);
        int startTileX = checkTiles[0] % mapSize;
        int startTileY = checkTiles[0] / mapSize;
        //xctargetDistance[checkTiles[0]] = Mathf.Min(Mathf.Abs(playerX - startTileX), Mathf.Abs(playerY - startTileY)) * Mathf.Sqrt(2) + Mathf.Abs(playerX - startTileX - (playerY - startTileY));
        targetDistance[checkTiles[0]] = new Vector2(playerX - startTileX, playerY - startTileY).magnitude;

        int currentTileIndex = 0;
        int backwardsSearchTile = playerPosition;
        int debug = currentTileIndex;

        //Finds the nearest path
        while (true)
        {
            if (checkTiles.Contains(playerPosition))
            {
                break;
            }
            if(checkTiles.Count == 0)
            {
                good = false;
                return;
            }
            //Finds all walkable tiles around the tiles it should scan
            List<int> walkableTiles = getWalkablePositions(checkTiles[currentTileIndex]);
            int abc = 0;
                for (int i = 0; i < walkableTiles.Count; i++)
                {
                    checkTileX = walkableTiles[i] % mapSize;
                    checkTileY = walkableTiles[i] / mapSize;
                    //shortTargetDistance[i] = Mathf.Min(Mathf.Abs(playerX - checkTileX), Mathf.Abs(playerY - checkTileY)) * Mathf.Sqrt(2) + Mathf.Abs(playerX - checkTileX - (playerY - checkTileY));
                    Vector2 towardPlayerVector = new Vector2(playerX - checkTileX, playerY - checkTileY);
                    shortTargetDistance[i] = towardPlayerVector.magnitude;
                    //Sets the templist of enemy distances
                    shortEnemyDistance[i] = enemyDistnace[checkTiles[currentTileIndex]] + Mathf.Sqrt(Mathf.Abs(checkTileX - (checkTiles[currentTileIndex] % mapSize)) + Mathf.Abs(checkTileY - (checkTiles[currentTileIndex] / mapSize)));
                    float sumDistance = shortEnemyDistance[i] + shortTargetDistance[i];
                    //Checks if there is a better path to walk and if so, override the old path (Aswell as a clause for if no path has been associated to that tile yet)
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
                if ((newValue < tempValue || tempValue == -1 || (newValue - tempValue < 0.01f  && new Vector2(startTileX - (walkableTiles[i] % mapSize), startTileY - (walkableTiles[i] / mapSize)).magnitude + segLength < new Vector2(startTileX - (tempIndex % mapSize), startTileY - (tempIndex / mapSize)).magnitude + tempSegLength)) && (enemyDistnace[walkableTiles[i]] != 0 || walkableTiles[i] == origin))
                {
                    tempIndex = walkableTiles[i];
                    tempValue = newValue;
                    tempSegLength = segLength;
                }
            }
            path.Add(DeSimplifyVector(tempIndex));
            if (tempIndex == origin)
            {
                break;
            }
            backwardsSearchTile = tempIndex;
        }

        path.Reverse();
        path.RemoveAt(0);
        test = path.ToArray();

    }
    IEnumerator Attack() //Attacks
    {
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
        onCooldown = true;
        SetParameter("Attack"); // Pontus animation
        yield return new WaitForSeconds(0.2f);
        GameObject checkCollision = GameObject.Instantiate(attackCollider, gameObject.transform.position + ((GameManager.player.transform.position - gameObject.transform.position) * (0.5f / (GameManager.player.transform.position - gameObject.transform.position).magnitude)), Quaternion.identity, gameObject.transform);
        yield return new WaitForSeconds(1f);
        rb.isKinematic = false;
        Destroy(checkCollision);
        yield return new WaitForSeconds(2f);
        onCooldown = false;
    }
    private void FixedUpdate()
    {
        if(test.Length > 0)
        {
            rb.AddForce((test[currentNode] - (Vector2)transform.position).normalized * Time.deltaTime * speed * ((Pollution.GetPolution * 0.1f) + 1));
            rb.velocity *= Mathf.Pow(0.9f, Time.deltaTime);
            if (Vector2.Distance(test[currentNode], (Vector2)transform.position) < 0.2f && currentNode < test.Length - 1)
            {
                currentNode++;
            }
        }
        else
        {
            rb.isKinematic = true;
            rb.velocity = Vector2.zero;
            rb.isKinematic = false;
        }
    }
    private void Update()
    {
        Vector2 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        if (!pathStarted && Vector2.Distance(gameObject.transform.position, playerPosition) < distanceStart * ((Pollution.GetPolution * 0.1f) + 1))
        {
            pathStarted = true;
            pathUpdate = updatePath();
            StartCoroutine(pathUpdate);
        }
        if (pathUpdate != null && Vector2.Distance(gameObject.transform.position, playerPosition) > distanceStart * 2 * ((Pollution.GetPolution * 0.1f) + 1))
        {
            StopCoroutine(pathUpdate);
        }
        if (Vector2.Distance(playerPosition, gameObject.transform.position) < 1.2f && !onCooldown)
        {
                StartCoroutine(Attack());
        }
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.y * 0.1f);
        if (!good)
        {
            Destroy(gameObject);
        }
        if(rb.velocity.x > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;

        }
        
        //Pontus Animations---------------------------------------------------------------------------------------------------------##########################################
        
        if(rb.velocity != Vector2.zero)
        {
            SetParameter("Moving");
        }else if(!onCooldown)
        {
            ClearParam();
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
    //Functions for converting things between Vector2 and an ID
    int SimplifyVector(Vector2 vector)
    {
        return (int)((vector.x) + (mapSize / 2)) + mapSize * (int)(-vector.y + (mapSize / 2));
    }
    Vector2 DeSimplifyVector(int simplifiedVector)
    {
        return new Vector2((((simplifiedVector % mapSize) - mapSize / 2)) + 0.5f, (mapSize / 2) - 0.5f - ((simplifiedVector - (simplifiedVector % mapSize)) / mapSize));
    }



    private void SetParameter(string name)
    {
        String[] array = { "Moving", "Attack", "Death" };
        foreach (String s in array)
        {
            if (s == name)
            {
                animator.SetBool(s, true);
            }
            else
            {
                animator.SetBool(s, false);
            }
        }
        
        
        
        
    }

    private void ClearParam()
    {
        String[] array = { "Moving", "Attack", "Death" };
        foreach (String s in array) animator.SetBool(s, false);
        
    }
}
