using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NestController : MonoBehaviour
{
    //Isak's kod
    [SerializeField]
    Transform player;
    [SerializeField]
    float spawnSpeed;
    [SerializeField]
    List<GameObject> enemyTypes = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void startSpawning()
    {
        foreach(Transform child in gameObject.transform)
        {
            //Makes all nests start spawnign enemy at a random ófsseted time
            float tempSpawnSpeed = spawnSpeed;
            child.gameObject.GetComponent<NestAI>().player = player;
            float spawningSpeed = Random.Range(tempSpawnSpeed / 2, tempSpawnSpeed * 2);
            StartCoroutine(child.gameObject.GetComponent<NestAI>().spawnEnemies(spawningSpeed, enemyTypes));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
