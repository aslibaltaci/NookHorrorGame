using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ReadNote : MonoBehaviour
{
    public TextMeshProUGUI text;
    public TextMeshProUGUI number;
    public GameObject note;

    public GameObject Button;

    bool colliding;
    bool open;
    public int LockNumber;

    public AudioSource Audio;
    public AudioClip PickUpPaper;

    // Start is called before the first frame update
    void Start()
    {
        text.enabled = false;
        note.SetActive(false);
        colliding = false;
        open = true;

        Button.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        number.text = LockNumber.ToString();

        if (colliding)
        {
            if(Input.GetKeyDown(KeyCode.Q) && open || Input.GetButtonDown("Interact") && open)
            {
                note.SetActive(true);
                open = false;
                Time.timeScale = 0;
                text.enabled = false;
                Button.SetActive(false);

                Audio.clip = PickUpPaper;
                Audio.Play();
            }
            else if(Input.GetKeyDown(KeyCode.Q) && !open || Input.GetButtonDown("Interact") && !open)
            {
                note.SetActive(false);
                open = true;
                Time.timeScale = 1;

                Audio.clip = PickUpPaper;
                Audio.Play();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            text.enabled = true;
            Button.SetActive(true);
            colliding = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            text.enabled = false;
            colliding = false;
            Button.SetActive(false);
        }

    }
}
