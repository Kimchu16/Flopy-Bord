using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public enum Direction
{
    Up,
    Down
}

public class PipeMovement : MonoBehaviour
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
    public Direction dir;

    // Start is called before the first frame update
    void Start()
    {
        float lowestTarget;
        float highestTarget;
        startTime = Time.time;
        if (dir == Direction.Up)
        {
            lowestTarget = transform.position.y + minMove;
            highestTarget = heightOffset;
        }
        else
        {
            lowestTarget = -heightOffset;
            highestTarget = transform.position.y - minMove;
        }
        rnd = Random.Range(lowestTarget, highestTarget);
        targetPosition = new Vector3(  transform.position.x, rnd, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if ((Time.time - startTime) > delay && !hasMoved)
        {
            MoveY();
            if (dir == Direction.Up && transform.position.y >= targetPosition.y || dir == Direction.Down && transform.position.y <= targetPosition.y)
            {
                hasMoved = true;
            }
        }
    }

    void MoveY()
    {
        if (dir == Direction.Up)
        {
            transform.position = transform.position + (Vector3.up * VertMoveSpeed) * Time.deltaTime;
        }
        else
        {
            transform.position = transform.position - (Vector3.up * VertMoveSpeed) * Time.deltaTime;
        }
    }
}
