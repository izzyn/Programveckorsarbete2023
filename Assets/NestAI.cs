using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class NestAI : MonoBehaviour
{
    List<GameObject> createdEnemies = new List<GameObject>();
    int mapsize;
    List<int> availableSpawns = new List<int>();
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(SimplifyVector(new Vector2(-43.5f, 48.5f)));
    }

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
                if (x != 0 || y != 0) //Makes it so the units can't spawn ontop of the nest
                {
                    totalSpawnLocations.Add(SimplifyVector(new Vector2(gameObject.transform.position.x - 1 + x, gameObject.transform.position.y - 1 + y)));
                }
            }
        }
        availableSpawns = totalSpawnLocations.Where(x => !terrainGenerator.GetWaterLoggedTiles.Contains(x)).ToList(); //Removes all the waterlogged tiles from the available spawn locations

        while (gameObject != null)
        {
            GameObject selectedEnemy = enemyTypes[UnityEngine.Random.Range(0, enemyTypes.Count)];
            Vector2 enemyPosition = DeSimplifyVector(UnityEngine.Random.Range(0, availableSpawns.Count));
            GameObject.Instantiate(selectedEnemy, new Vector3(enemyPosition.x, enemyPosition.y, enemyPosition.y * 0.1f), Quaternion.identity);
            yield return new WaitForSeconds(cooldown);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    int SimplifyVector(Vector2 vector)
    {
        return Mathf.Abs((int)((vector.x - 0.5f) + (mapsize/2)) + mapsize * (Mathf.Abs((int)(vector.y + 0.5f - (mapsize/2)))));
    }
    Vector2 DeSimplifyVector(int simplifiedVector)
    {
        return new Vector2((((simplifiedVector % mapsize) - mapsize/2) * -1) + 0.5f, (simplifiedVector - (simplifiedVector % mapsize))/mapsize + 0.5f);
    }
}