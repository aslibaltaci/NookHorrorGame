using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    private AudioSource Sound;

    public AudioClip Breath;
    public AudioClip FootStep;

    // Start is called before the first frame update
    void Start()
    {
        Sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Tab))
        {
            Sound.clip = Breath;
            Sound.Play();
            Sound.loop = true;
        }
    }
}
