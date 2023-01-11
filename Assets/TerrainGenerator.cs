using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Unity.Mathematics;
using System.Linq;

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
    [SerializeField, Range(1, 10)]
    int waterPointyness;
    [SerializeField, Range(1, 10)]
    int waterGenerationDepth;
    [SerializeField, Range(0f, 100000)]
    int seed; //Dictates everything except for offsets
    [SerializeField, Range(0f, 1f)]
    float treeNoise;
    [SerializeField, Range(0f, 1f)]
    float treeThreshold;
    [SerializeField, Range(0f, 1f)]
    float treeOffset;
    [SerializeField]
    GameObject treePrefab;
    [SerializeField]
    GameObject treeGroup;
    [SerializeField]
    GameObject bushObject;
    [SerializeField, Range(0f, 1f)]
    float bushRange;
    [SerializeField, Range(0f, 1f)]
    float bushNoise;
    [SerializeField, Range(0f, 1f)]
    float bushOffset;


    List<int> occupiedTiles = new List<int>(); //1 dimensional list to index the occupied tiles (2 dimensions would look simpler but be more computationally expensive)
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

                float noiseNumber = NoiseFunctions.ridgedFractalNoise(x, y, seed, waterNoise, waterGenerationDepth, waterPointyness); //Generates a random perlin value for every cordinate
                Vector3Int tilePosition = new Vector3Int((mapSize / 2) * -1 + x, (mapSize / 2) * -1 + y, 0); //Sets the position so that the map is centered on 0, 0
                if(noiseNumber > waterThreshold && !(y < 5 + mapSize/2 && y > -5 + mapSize/2 && x < 5 + mapSize/2 && x > -5 + mapSize/2)) //Sets the water depending on the threshhold and makes sure there is an area for the player to spawn in
                {
                    tilemap.SetTile(tilePosition, water); //sets the tiles
                }
                else
                {
                    tilemap.SetTile(tilePosition, ground);
                }
            }
        }
        GenerateObjects(treePrefab, treeNoise, treeOffset,  treeThreshold, seed); //Generates the objects that we desire on the map
        GenerateObjects(bushObject, bushNoise, bushOffset, bushRange, seed);
    }

    void GenerateObjects(GameObject spawnObject, float noise, float offset, float threshold, int presetSeed = 0)
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
                float offsetX = UnityEngine.Random.Range(-offset, offset); //Offsets the objects for aesthetic reasons
                float offsetY = UnityEngine.Random.Range(-offset, offset);
                float noiseNumber = Math.Clamp(Mathf.PerlinNoise(x * noise + seed*2, y * noise + seed*2), 0, 1); //Generates a random perlin value for every cordinate
                Vector3Int tilePosition = new Vector3Int((mapSize / 2) * -1 + x, (mapSize / 2) * -1 + y, 0); //Sets the position so that the map is centered on 0, 0
                Vector3 treePosition = new Vector3((mapSize / 2) * -1 + x + offsetX - 0.5f, (mapSize / 2) * -1 + y + offsetY, ((mapSize / 2) * -1 + y + offsetY)*0.1f);
                Vector3Int positionRoundedDown = new Vector3Int((int)Math.Floor(treePosition.x), (int)Math.Floor(treePosition.y), 0); //Checks the adjacent tiles so trees don't spawn on water
                Vector3Int positionRoundedUp = new Vector3Int((int)Math.Ceiling(treePosition.x), (int)Math.Ceiling(treePosition.y), 0);

                if (noiseNumber > threshold && tilemap.GetTile(positionRoundedUp) == ground && tilemap.GetTile(positionRoundedDown) == ground && !occupiedTiles.Contains(y*mapSize + x))
                {
                    GameObject placedTree = GameObject.Instantiate(spawnObject, treePosition, Quaternion.identity, treeGroup.transform);
                    occupiedTiles.Add(y * mapSize + x); //Indexes the placed objects so it doesn't cause objects piling on the same tile
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
