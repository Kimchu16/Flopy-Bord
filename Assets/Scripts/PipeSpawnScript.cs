using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum pipeType
{
    Regular,
    Up,
    Down
}

public class PipeSpawnScript : MonoBehaviour
{

    public GameObject pipe;
    public GameObject downPipe;
    public GameObject upPipe;
    public BirdScript birdScript;
    public PipeMovement movement;
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

                if (rnd < 70)
                {
                    SpawnPipe(pipe, pipeType.Regular);
                    
                }
                else
                {
                    if (rnd % 2 == 0)
                    {
                        SpawnPipe(upPipe, pipeType.Up);
                    }
                    else
                    {
                        SpawnPipe(downPipe, pipeType.Down);
                    }
                }

                timer = 0;
            }
        }
    }

    void SpawnPipe(GameObject pipe, pipeType Type)
    {
        float mid = transform.position.y;
        int moveOffSet = 3;

        float lowestSpawnPoint = mid - heightOffset;
        float highestSpawnPoint = mid + heightOffset;

        if (Type == pipeType.Up)
        {
            highestSpawnPoint = mid + heightOffset - moveOffSet;
        }
        else if (Type == pipeType.Down)
        {
            lowestSpawnPoint = mid - heightOffset + moveOffSet;
        }

        float spawnPoint = Random.Range(lowestSpawnPoint, highestSpawnPoint);

        GameObject pipeObject = Instantiate(pipe, new Vector3(transform.position.x, spawnPoint, 0), transform.rotation);
        /*
        if (Type == pipeType.Up)
        {
            UpPipeMovement comp = pipeObject.GetComponent<UpPipeMovement>();
            comp.offSet = spawnPoint;
        }
        else if (Type == pipeType.Down)
        {
            
        }
        */
    }

}
