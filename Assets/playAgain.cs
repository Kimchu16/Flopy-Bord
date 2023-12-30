using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playAgain : MonoBehaviour
{
    public DataManager dm;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        if (Input.GetKeyDown(KeyCode.Space)) 
        { 
            dm.RestartGame();
        }
    }
}
