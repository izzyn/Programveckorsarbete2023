using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    GameObject lossObject;
    [SerializeField]
    static int hp = 5;
    public static int reduceHp(int value) => hp -= value;
    public static int restoreHP() => hp = 5000;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(hp <= 0)
        {
            lossObject.GetComponent<ScoreCounter>().GameOver();
        }
    }
}
