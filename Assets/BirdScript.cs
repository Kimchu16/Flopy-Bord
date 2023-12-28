using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public SpriteRenderer mySpriteRenderer;
    public Sprite[] bird;
    public float flapStrength = 18;
    public LogicScript logic;
    public bool birdIsAlive = true;
    public bool start = false;
    public float BottomDeadzone = -20;
    public float TopDeadzone = 20;
    AudioSource bonk;
    AudioSource flap;
    public GameObject startHint;
    
    //bird angle change physics
    public float flopAngle = 120;
    public float rotSpeed = 0.5f;
    private bool isBirdFlapping = false;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        AudioSource[] audio = GetComponents<AudioSource>();
        myRigidBody.gravityScale = 0;
        bonk = audio[0];
        flap = audio[1];

    }

    // Update is called once per frame
    void Update()
    {
        if (!start)
        {
            checkStart();
        }
        
        if (start)
        {
            AdjustAngle();
            BirdFlap();
        }
    
        //if bird goes off screen
        if (transform.position.y < BottomDeadzone)
        {
            logic.GameOver();
            Destroy(gameObject);
        }
        else if (transform.position.y > TopDeadzone)
        {
            birdIsAlive = false;
            logic.GameOver();
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        //guardclause
        if (!birdIsAlive)
        {
            return;
        }

        birdIsAlive = false;
        bonk.Play();
        logic.GameOver();
    }

    private void BirdFlap()
    {
        //if space is held bird goes up and changes sprite to wing down
        if ((Input.GetKeyDown(KeyCode.Space) || (Input.GetMouseButtonDown(0))) && birdIsAlive == true)
        {
            myRigidBody.velocity = Vector2.up * flapStrength;
            mySpriteRenderer.sprite = bird[0];
            flap.Play();
            isBirdFlapping = true;
        }
        //if space is released bird changes sprite back to default
        if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0))
        {
            mySpriteRenderer.sprite = bird[1];
            isBirdFlapping = false;
        }
    }

    private void AdjustAngle()
    {
        if(isBirdFlapping)
        {
            float tiltAroundZ = flopAngle;
            Quaternion target = Quaternion.Euler(0, 0, tiltAroundZ);
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * rotSpeed + 10);
        }
        else
        {
            float tiltAroundZ =  -70;
            Quaternion target = Quaternion.Euler(0, 0, tiltAroundZ);
            transform.rotation = Quaternion.Slerp(transform.rotation, target, (Time.deltaTime * rotSpeed)/2); //Divided by 2 in order to slow down rotation
        }
    }

    public void checkStart()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)))
        {
            Debug.Log("start");
            start = true;
            startHint.SetActive(false);
            myRigidBody.gravityScale = 6;
        }
    }
}
