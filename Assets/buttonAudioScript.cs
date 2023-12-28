using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class buttonAudioScript : MonoBehaviour
{
    AudioSource hover;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource[] audio = GetComponents<AudioSource>();
        hover = audio[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onHover()
    {
        hover.Play();
    }
}
