using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class NestAI : MonoBehaviour
{
    public Transform player;
    List<GameObject> createdEnemies = new List<GameObject>();
    int mapsize;
    List<int> availableSpawns = new List<int>();
    // Start is called before the first frame update
    void Start()
    {
        int id = SimplifyVector(new Vector2(-50.5f, 0.5f));
        Debug.Log(id);
        Debug.Log(DeSimplifyVector(id));


    }
    

    //NOTE: DO NOT CHANGE THIS CODE, I HOTFIXED THIS AT 00:00 AND IT MIGHT BREAK IF TOUCHED
    public IEnumerator spawnEnemies(float cooldown, List<GameObject> enemyTypes)
    {
        TerrainGenerator terrainGenerator = GameObject.Find("TerrainGenerator").GetComponent<TerrainGenerator>();
        mapsize = terrainGenerator.GetMapSize;
        int positionSimple = SimplifyVector(gameObject.transform.position);
        List<int> totalSpawnLocations = new List<int>();
        for (int y = 0; y < 3; y++) //Gets all the total 
        {
            for (int x = 0; x < 3; x++)
            {
                int tryLocation = ((y + (((gameObject.GetComponent<ObjectData>().id - (gameObject.GetComponent<ObjectData>().id % mapsize)) / mapsize)) - 1) * mapsize) + (x + (gameObject.GetComponent<ObjectData>().id % mapsize));
                if ((x != 1 || y != 1) && tryLocation % mapsize != 0 && Mathf.Abs((x + (gameObject.GetComponent<ObjectData>().id % mapsize) - gameObject.GetComponent<ObjectData>().id % mapsize)) <= 3) //Makes it so the units can't spawn ontop of the nest
                {
                    totalSpawnLocations.Add(tryLocation);
                }
            }
        }
        availableSpawns = totalSpawnLocations.Where(x => !terrainGenerator.GetWaterLoggedTiles.Contains(x-1)).ToList(); //Removes all the waterlogged tiles from the available spawn locations
        Debug.Log(availableSpawns.Count);

        while (gameObject != null)
        {
            if(availableSpawns.Count > 0)
            {
                yield return new WaitForSeconds(cooldown);
                GameObject selectedEnemy = enemyTypes[UnityEngine.Random.Range(0, enemyTypes.Count)];
                Vector2 enemyPosition = DeSimplifyVector(availableSpawns[UnityEngine.Random.Range(0, availableSpawns.Count)]);
                if (enemyPosition.x >= ((mapsize / 2f)*-1) + 0.5f && enemyPosition.x <= mapsize / 2 - 0.5f && enemyPosition.y >= ((mapsize / 2f) * -1) + 0.5f && enemyPosition.y <= mapsize / 2 - 0.5f)
                {
                    GameObject enemy = GameObject.Instantiate(selectedEnemy, new Vector3(enemyPosition.x, enemyPosition.y, enemyPosition.y * 0.1f), Quaternion.identity);
                    enemy.GetComponent<AIScript>().target = player;
                    enemy.GetComponent<AIScript>().initiateSeeking();

                }
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    int SimplifyVector(Vector2 vector)
    {
        return (int)((vector.x + 0.5f) + (mapsize/2)) + mapsize * (int)(-vector.y + 0.5f + (mapsize/2));
    }
    Vector2 DeSimplifyVector(int simplifiedVector)
    {
        return new Vector2((((simplifiedVector % mapsize) - mapsize/2)) - 0.5f,-(mapsize/2) +0.5f + ((simplifiedVector - (simplifiedVector % mapsize))/mapsize));
    }
}