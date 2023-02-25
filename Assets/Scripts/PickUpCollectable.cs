using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickUpCollectable : MonoBehaviour
{
    public GameObject door;
    public TextMeshProUGUI text;
    public TextMeshProUGUI text1;
    public GameObject Button;
    public float timeRemaining;

    bool startTimer;
    public bool colliding;

    private void Start()
    {
        text.enabled = false;
        text1.enabled = false;
        startTimer = false;
        colliding = false;
        gameObject.GetComponent<MeshRenderer>().enabled = true;
        door.GetComponent<OpenDoor>().enabled = false;
        door.GetComponent<BoxCollider>().enabled = false;
        Button.SetActive(false);
    }

    private void Update()
    {
        if (startTimer)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;          
                print(timeRemaining);
            }
        }

        if(timeRemaining <= 0)
        {
            text.enabled = false;
        }

        if(colliding)
        {
            if (Input.GetKeyDown(KeyCode.Q) || Input.GetButtonDown("Interact"))
            {
                gameObject.GetComponent<MeshRenderer>().enabled = false;
                gameObject.GetComponent<BoxCollider>().enabled = false;
                gameObject.GetComponent<Collider>().enabled = false;
                door.GetComponent<OpenDoor>().enabled = true;
                door.GetComponent<BoxCollider>().enabled = true;
                text.enabled = true;
                text1.enabled = false;
                startTimer = true;
                Button.SetActive(false);
                colliding = false;
            }
        }
   
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            text1.enabled = true;
            Button.SetActive(true);
            colliding = true;          
        }
    }

    private void OnTriggerExit(Collider other)
    {
        text1.enabled = false;
        colliding = false;
        Button.SetActive(false);
    }
}
