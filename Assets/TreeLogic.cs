using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//fredrik
public class TreeLogic : MonoBehaviour
{
    public GameObject log;
    public weaponSystem wS;

    private void Start()
    {
        wS = FindObjectOfType<weaponSystem>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("weapon")&&wS.IsAxe)
        {
            Instantiate(log, gameObject.transform.position + new Vector3(0f, 0.3f, 0f), Quaternion.identity);
            GameObject.Destroy(gameObject);
        }
    }
}
