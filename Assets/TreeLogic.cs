using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeLogic : MonoBehaviour
{
    public GameObject log;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
            Instantiate(log, gameObject.transform.position + new Vector3(0f, 0.3f, 0f), Quaternion.identity);
            GameObject.Destroy(gameObject);
    }
}
