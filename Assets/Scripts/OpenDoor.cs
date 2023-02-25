using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OpenDoor : MonoBehaviour
{
    //public Transform door;
    public TextMeshProUGUI text;
    public GameObject DoorButton;
    public Animator doorAnim;

    public bool colliding;
    private bool open;

    public GameObject Collider;

    public AudioSource Audio;

    public AudioClip Opening;

    // Start is called before the first frame update
    void Start()
    {
        text.enabled = false;
        doorAnim.GetComponent<Animator>();
        open = true;
        DoorButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(colliding)
        {
            if (Input.GetKeyDown(KeyCode.Q) || Input.GetButtonDown("Interact"))
            {
                doorAnim.SetBool("PlayAnim", true);

                Audio.clip = Opening;
                Audio.Play();

                Collider.GetComponent<BoxCollider>().enabled = false;
                text.enabled = false;
                DoorButton.SetActive(false);
                StartCoroutine(Countdown());
            }
        }

        print(colliding);
    }

    private void OnTriggerEnter(Collider other)
    {
           text.enabled = true;
        DoorButton.SetActive(true);
        colliding = true;
    }

    private void OnTriggerExit(Collider other)
    {
            text.enabled = false;
        DoorButton.SetActive(false);
        colliding = false;
    }

    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(1);
        colliding = false;
    }
}
