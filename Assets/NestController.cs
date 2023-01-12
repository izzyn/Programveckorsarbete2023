using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NestController : MonoBehaviour
{
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
            StartCoroutine(child.gameObject.GetComponent<NestAI>().spawnEnemies(spawnSpeed, enemyTypes));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
