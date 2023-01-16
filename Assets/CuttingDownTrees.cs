using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingDownTrees : MonoBehaviour
{
    public GameObject player;
    public GameObject tree;
    public float distance;
    // Start is called before the first frame update
    void Start()
    {
        player = GameManager.player;
        tree = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(player.transform.position, tree.transform.position + new Vector3(0f, 0.5f, 0f));

        if (distance < 0.5 && Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject.Destroy(gameObject);
        }
    }
}
