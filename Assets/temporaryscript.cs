using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class temporaryscript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            death();
        }

        void death()
        {
            if(GameManager.dayCount > GameManager.highscore)
            {
                GameManager.highscore = GameManager.dayCount;
            }
        }
    }
}
