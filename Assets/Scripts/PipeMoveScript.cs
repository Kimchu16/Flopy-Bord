using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    public float moveSpeed = 5;
    public float deadzone = -45;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = this.transform.position + (Vector3.left * moveSpeed) * Time.deltaTime; //deltaTime keeps timing consistent acorss different devices

        if (this.transform.position.x < deadzone)
        {
            Debug.Log("Pipe destroyed");
            Destroy(gameObject);
        }
    }
}
