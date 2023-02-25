using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBreath : MonoBehaviour
{
    public AudioSource Audio;

    public AudioClip Breath;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        Audio.clip = Breath;
        Audio.Play();
        Destroy(gameObject);
    }
}
