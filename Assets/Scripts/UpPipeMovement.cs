using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UpPipeMovement : MonoBehaviour
{
    public Vector3 targetPosition;
    public float smoothTime = 0.5f;
    public float moveSpeed = 5;
    public float upwardSpeed = 1;
    public float deadzone = -45;
    public float heightOffset = 4;
    public float rnd;
    public bool changeMovement;
    public float startTime = 0;
    public bool hasMoved = false;
    private readonly float delay = 1;

    // Start is called before the first frame update
    void Start()
    {
        changeMovement = false;
        startTime = Time.time;
        float lowestSpawnPoint = transform.position.y - heightOffset;
        float highestSpawnPoint = transform.position.y + heightOffset;
        rnd = Random.Range(lowestSpawnPoint, highestSpawnPoint);
        targetPosition = new Vector3(  transform.position.x, rnd, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if ((!changeMovement) || hasMoved )
        {
           
            MoveX();

            if ((Time.time - startTime) > delay)
            {
                changeMovement = true;
            }
        }
        else
        {
            MoveY();
            MoveX();

            if (transform.position.y >= targetPosition.y)
            {
                hasMoved = true;
            }
        }

        if (transform.position.x < deadzone)
        {
            Debug.Log("Pipe destroyed");
            Destroy(gameObject);
        }

    }

    float MoveX()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
        return transform.position.x;
    }

    void MoveY()
    {
        transform.position = transform.position + (Vector3.up * moveSpeed) * Time.deltaTime;
    }
}
