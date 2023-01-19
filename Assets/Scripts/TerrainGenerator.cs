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
    public int GetMapSize => mapSize;
    [SerializeField]
    Tilemap waterTileMap;
    [SerializeField]
    Tilemap tilemap; //referance tilemap
    public Tilemap GetTileMap => tilemap;
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
    [SerializeField, Range(0f, 1f)]
    float nestDensity; //Is inversed
    [SerializeField, Range(0, 100)]
    int nestDistance;
    [SerializeField, Range(0f, 1f)]
    float nestAmount; //Is inversed
    [SerializeField]
    GameObject treePrefab;
    [SerializeField]
    GameObject treeGroup;
    [SerializeField]
    GameObject bushObject;
    [SerializeField]
    GameObject nestObject;
    [SerializeField]
    GameObject nestGroup;
    [SerializeField, Range(0f, 1f)]
    float bushRange;
    [SerializeField, Range(0f, 1f)]
    float bushNoise;
    [SerializeField, Range(0f, 1f)]
    float bushOffset;

    List<int> occupiedTiles = new List<int>(); //1 dimensional list to index the occupied tiles (2 dimensions would look simpler but be more computationally expensive)
    public List<int> GetOccupiedTiles => occupiedTiles; //Getter for the occupied tile grid
    List<int> waterLoggedTiles = new List<int>();
    public List<int> GetWaterLoggedTiles => waterLoggedTiles;
    // Start is called before the first frame update
    void Start()
    {
        // This creates a Grid Graph
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
                    waterTileMap.SetTile(tilePosition, water); //sets the tiles
                    tilemap.SetTile(tilePosition, water); //sets the tiles
                    waterLoggedTiles.Add((mapSize * mapSize - mapSize) - y * mapSize + x);
                }
                else
                {
                    tilemap.SetTile(tilePosition, ground);
                }
            }
        }
        //Generates the boundry around the map
        for(int y = 0; y < mapSize+30; y++)
        {
            for(int x = 0; x < mapSize+30; x++)
            {
                Vector3Int checkPosition = new Vector3Int(((mapSize+30) / 2) * -1 + x, ((mapSize+30) / 2) * -1 + y, 0);
                if (tilemap.GetTile(checkPosition) != ground)
                {
                    waterTileMap.SetTile(checkPosition, water); //sets the tiles
                    tilemap.SetTile(checkPosition, water); //sets the tiles
                }
            }
        }
        int attempts = 0;
        while(nestGroup.transform.childCount < 1 && attempts < 100)
        {
            GenerateObjects(treePrefab, treeNoise, treeOffset, treeThreshold, treeGroup.transform, seed, 0, 0.5f); //Generates the objects that we desire on the map
            GenerateObjects(bushObject, bushNoise, bushOffset, bushRange, treeGroup.transform, seed, 0, 0.5f);
            GenerateObjects(nestObject, nestDensity, 0, nestAmount, nestGroup.transform, seed, nestDistance, 0.5f);
            if(nestGroup.transform.childCount < 1)
            {
                attempts++;
                seed = UnityEngine.Random.Range(100, 100000); //Generates a new seed if the generation failed based on set conditions
                Debug.Log("Generation failed, new seed is: " + seed);
            }
        }
        if(attempts >= 100) //To prevent infinite loops, it automatically stops after 100 iterations
        {
            //Does nothing at the moment
            generationFail();
        }
        else
        {
            attempts = 0;
            nestGroup.GetComponent<NestController>().startSpawning(); //Makes all nests start spawning enemies after the terrain has finished loading
        }
    }

    void GenerateObjects(GameObject spawnObject, float noise, float offset, float threshold, Transform parentObject, int presetSeed = 0, float distance = 0, float constantOffset = 0)
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
                //Sets the position, not sure about the random numbers, but it works.
                Vector3 treePosition = new Vector3((mapSize / 2) * -1 + x, (mapSize / 2) * -1 + y + offsetY - constantOffset  + 0.5f, ((mapSize / 2) * -1 + y - offsetY - 0.5f)*0.1f);
                Vector3Int positionRoundedDown = new Vector3Int((int)Math.Floor(treePosition.x), (int)Math.Floor(treePosition.y), 0); //Checks the adjacent tiles so trees don't spawn on water
                Vector3Int positionRoundedUp = new Vector3Int((int)Math.Ceiling(treePosition.x), (int)Math.Ceiling(treePosition.y), 0);
                Vector3Int XRoundedUp = new Vector3Int((int)Math.Ceiling(treePosition.x), (int)Math.Floor(treePosition.y), 0);
                Vector3Int YRoundedUp = new Vector3Int((int)Math.Floor(treePosition.x), (int)Math.Ceiling(treePosition.y), 0);

                float originDistance = Mathf.Sqrt(Mathf.Pow(Mathf.Abs(treePosition.x), 2) + Mathf.Pow(Mathf.Abs(treePosition.y), 2)); //Gets the distance from 0, 0 (doesn't need subtraction since the co-ordinates are 0, 0)

                if (noiseNumber > threshold &&  !waterLoggedTiles.Contains((mapSize * mapSize - mapSize) - y * mapSize + x)  && !occupiedTiles.Contains((mapSize * mapSize - mapSize) - y * mapSize + x) && originDistance >= distance * 0.01f * (mapSize/2))
                {
                    GameObject placedTree = GameObject.Instantiate(spawnObject, treePosition, Quaternion.identity, parentObject);
                    occupiedTiles.Add((mapSize*mapSize - mapSize) - y * mapSize + x); //Indexes the placed objects so it doesn't cause objects piling on the same tile
                    placedTree.GetComponent<ObjectData>().id = (mapSize * mapSize - mapSize) - y * mapSize + x;
                    //This formula sets the position things that might destroy the water and object checks, do not touch
                    placedTree.transform.position = new Vector3(placedTree.transform.position.x + 0.5f + offsetX, placedTree.transform.position.y + 0.5f + offsetY, (placedTree.transform.position.y + 0.5f + offsetY) * 0.1f);
                }
            }
        }
    }
    void generationFail()
    {
        

    }

    // Update is called once per frame
    void Update()
    {

    }
}
