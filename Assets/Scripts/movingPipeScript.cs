using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPipeScript : MonoBehaviour
{
    public float startTime;
    public GameObject upPipe;

    private void Awake()
    {
        startTime = Time.time;

        if (upPipe)
        {
            Debug.Log("up");
        }
        else
        {
            Debug.Log("down");
        }
       
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Target()
    {
        
    }
}
