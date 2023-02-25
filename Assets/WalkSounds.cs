using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkSounds : MonoBehaviour
{
    public AudioSource footStep;
    public AudioSource breathing;


    void Start()
    {

    }
    void Update()
    {
        if(Input.GetAxis("Horizontal") < 0 || Input.GetAxis("Vertical") > 0)
        {
            footStep.enabled = true;
            breathing.enabled = false;
        }
        else 
        {
            footStep.enabled = false;
            breathing.enabled = true;
        }
    }
}
