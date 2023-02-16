using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeLogic : MonoBehaviour
{
    public GameObject log;

    public weaponSystem weaponSystem;
    public GameObject weapon;

    private void Start()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("weapon"))
        {
            Instantiate(log, gameObject.transform.position + new Vector3(0f, 0.3f, 0f), Quaternion.identity);
            GameObject.Destroy(gameObject);
        }
    }
}
