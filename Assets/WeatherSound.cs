using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherSound : MonoBehaviour
{
    public AudioSource Audio;

    public AudioClip Weather;


    // Start is called before the first frame update
    void Start()
    {
        Audio.clip = Weather;
        Audio.Play();
        Audio.loop = true;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
