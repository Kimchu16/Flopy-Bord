using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public enum direction
{
    Up,
    Down
}

public class UpPipeMovement : MonoBehaviour
{
    public Vector3 targetPosition;
    public float VertMoveSpeed = 5;
    public float heightOffset = 4;
    public float rnd;
    public float minMove = 1;
    public float startTime = 0;
    public bool hasMoved = false;
    public readonly float delay = 1;
    public float offSet = 0;
    public direction dir;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        float lowestTarget = transform.position.y + minMove;
        float highestTarget = heightOffset;
        rnd = Random.Range(lowestTarget, highestTarget);
        targetPosition = new Vector3(  transform.position.x, rnd, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if ((Time.time - startTime) > delay && !hasMoved)
        {
            MoveY();

            if (transform.position.y >= targetPosition.y)
            {
                hasMoved = true;
            }
        }
    }

    void MoveY()
    {
        transform.position = transform.position + (Vector3.up * VertMoveSpeed) * Time.deltaTime;
    }
}
