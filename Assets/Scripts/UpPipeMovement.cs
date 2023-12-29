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
    public bool changeMovement = false;
    private float timer = 0;
    public float startTime = 0;
    public bool hasMoved = false;

    // Start is called before the first frame update
    void Start()
    {
        float lowestSpawnPoint = this.transform.position.y - heightOffset;
        float highestSpawnPoint = this.transform.position.y + heightOffset;
        rnd = Random.Range(lowestSpawnPoint, highestSpawnPoint);
        this.targetPosition = new Vector3(this.transform.position.x, rnd, 0);
        startTime = Time.fixedTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (!changeMovement || hasMoved )
        {
            MoveX();
            timer += Time.fixedTime;

            if (timer - startTime > 500)
            {
                changeMovement = true;
                timer = 0;
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



        if (transform.position.y == this.targetPosition.y)
        {
            changeMovement = false; // Reset the flag to go back to moving left
        }

        if (this.transform.position.x < deadzone)
        {
            Debug.Log("Pipe destroyed");
            Destroy(gameObject);
        }

    }

    float MoveX()
    {
        this.transform.position = this.transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
        return this.transform.position.x;
    }

    void MoveY()
    {
        this.transform.position = this.transform.position + (Vector3.up * moveSpeed) * Time.deltaTime;
    }
}
