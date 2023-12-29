using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{

    public GameObject pipe;
    public GameObject downPipe;
    public GameObject upPipe;
    public BirdScript birdScript;
    public float spawnRate = 2;
    private float timer = 2;
    public float heightOffset = 4;
    public int rnd;
   
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if (birdScript.start == true)
        {
            //adds a count to the timer each frame if timer < spawnRate
            if (timer < spawnRate)
            {
                timer += Time.deltaTime;
            }
            else
            //Spawns pipe and resets timer
            {
                rnd = Random.Range(1, 100);

                if (rnd < 100)
                {
                    SpawnPipe(pipe);
                    
                }
                else
                {
                    if (rnd % 2 == 0)
                    {
                        SpawnPipe(upPipe);
                    }
                    else
                    {
                        SpawnPipe(downPipe);
                    }
                }

                timer = 0;
            }
        }
    }

    void SpawnPipe(GameObject pipe)
    {
        float lowestSpawnPoint = transform.position.y - heightOffset;
        float highestSpawnPoint = transform.position.y + heightOffset;

        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestSpawnPoint, highestSpawnPoint), 0), transform.rotation);
    }

}
