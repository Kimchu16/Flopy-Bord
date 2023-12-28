using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMiddleScript : MonoBehaviour
{
    public LogicScript logic;
    public bool canChange = true;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            if (canChange)
            {
                logic.AddScore(1);
                StartCoroutine(ChangeLogic());
            }
        }
    }

    //Fixes bug where Score is incremented multiple times when bird gets stuck on pipe
    IEnumerator ChangeLogic()
    {
        Debug.Log(canChange);
        canChange = false;
        yield return new WaitForSeconds(0.1f);
        canChange = true;
    }
}
