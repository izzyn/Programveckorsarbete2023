using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

//fredrik
public class TreeLogic : MonoBehaviour
{
    public GameObject log;
    public weaponSystem wS;

    private void Start()
    {
        //finds the weaponSystems script to access a variable
        wS = FindObjectOfType<weaponSystem>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //when a tree collides with an object with the tag weapon, it checks if the variable IsAxe is true to find out if the weapon is an axe or not
        if (collision.gameObject.CompareTag("weapon")&&wS.IsAxe)
        {
            //destroys the tree and spawns a log in its place
            Instantiate(log, gameObject.transform.position + new Vector3(0f, 0.3f, 0f), Quaternion.identity);
            GameObject.Destroy(gameObject);
        }
    }
}
