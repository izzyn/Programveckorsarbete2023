using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Unity.Mathematics;

public class TerrainGenerator : MonoBehaviour
{
    [SerializeField, Range(10, 1000)]
    int mapSize; //total map size
    [SerializeField]
    Tilemap tilemap; //referance tilemap
    [SerializeField]
    Tile ground;
    [SerializeField]
    Tile water;
    [SerializeField, Range(0.0f, 1.0f)]
    float waterThreshold; //The threshold for the value so that the water can spawn (higher number = less water)
    [SerializeField, Range(0f, 1f)]
    float waterNoise; //dictates the amount of noise  (higher number = more differance) 
    [SerializeField, Range(0f, 100000)]
    int seed;
    [SerializeField, Range(0f, 1f)]
    float treeNoise;
    [SerializeField, Range(0f, 1f)]
    float treeThreshold;
    [SerializeField]
    GameObject treePrefab;
    [SerializeField]
    GameObject treeGroup;
    // Start is called before the first frame update
    void Start()
    {
        GenerateTerrain(seed);
    }
    void GenerateTerrain(int presetSeed = 0)
    {
        int seed;
        tilemap.ClearAllTiles(); //Resets the map
        if(presetSeed < 100)
        {
            seed = UnityEngine.Random.Range(100, 100000); //Generates the seed value
        }
        else
        {
            seed = presetSeed;
        }
        for(int y = 0; y < mapSize; y++)
        {
            for(int x = 0; x < mapSize; x++)
            {

                float noiseNumber = Math.Clamp(Mathf.PerlinNoise(x * waterNoise + seed, y * waterNoise + seed), 0, 1); //Generates a random perlin value for every cordinate
                Vector3Int tilePosition = new Vector3Int((mapSize / 2) * -1 + x, (mapSize / 2) * -1 + y, 0); //Sets the position so that the map is centered on 0, 0
                if(noiseNumber > waterThreshold) //Sets the water depending on the threshhold
                {
                    tilemap.SetTile(tilePosition, water); //sets the tiles
                }
                else
                {
                    tilemap.SetTile(tilePosition, ground);
                }
            }
        }
        GenerateTrees(seed);
    }
    void GenerateTrees(int presetSeed = 0)
    {
        int seed;
        if (presetSeed < 100)
        {
            seed = UnityEngine.Random.Range(100, 100000); //Generates the seed value
        }
        else
        {
            seed = presetSeed;
        }
        for (int y = 0; y < mapSize; y++)
        {
            for (int x = 0; x < mapSize; x++) {
                float offsetX = UnityEngine.Random.Range(-0.25f, 0.25f);
                float offsetY = UnityEngine.Random.Range(-0.25f, 0.25f);
                float noiseNumber = Math.Clamp(Mathf.PerlinNoise(x * treeNoise + seed*2, y * treeNoise + seed*2), 0, 1); //Generates a random perlin value for every cordinate
                Vector3Int tilePosition = new Vector3Int((mapSize / 2) * -1 + x, (mapSize / 2) * -1 + y, 0); //Sets the position so that the map is centered on 0, 0
                Vector3 treePosition = new Vector3((mapSize / 2) * -1 + x + offsetX - 0.5f, (mapSize / 2) * -1 + y + offsetY, ((mapSize / 2) * -1 + y + offsetY)*0.1f);
                Vector3Int positionRoundedDown = new Vector3Int((int)Math.Floor(treePosition.x), (int)Math.Floor(treePosition.y), 0);
                Vector3Int positionRoundedUp = new Vector3Int((int)Math.Ceiling(treePosition.x), (int)Math.Ceiling(treePosition.y), 0);

                if (noiseNumber > treeThreshold && tilemap.GetTile(positionRoundedUp) == ground && tilemap.GetTile(positionRoundedDown) == ground)
                {
                    GameObject placedTree = GameObject.Instantiate(treePrefab, treePosition, Quaternion.identity, treeGroup.transform);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
