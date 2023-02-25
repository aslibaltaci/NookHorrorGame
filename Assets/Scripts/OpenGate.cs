using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGate : MonoBehaviour
{

    public GameObject GateTXT;
    public GameObject LockMenu;

    public GameObject Camera;

    private bool inCollision = false;

    public bool menuOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        GateTXT.SetActive(false);
        LockMenu.SetActive(false);

    }
    // Update is called once per frame
    void Update()
    {
        if (inCollision && Input.GetButtonDown("Interact"))
        {
            GateTXT.SetActive(false);
            LockMenu.SetActive(true);

            

            menuOpen = true;

            Camera.GetComponent<CameraMovement>().enabled = false;
        }
        if (inCollision && Input.GetButtonDown("Crouch/Back"))
        {
            GateTXT.SetActive(true);
            LockMenu.SetActive(false);

            menuOpen = false;

            Cursor.lockState = CursorLockMode.Locked;

            Camera.GetComponent<CameraMovement>().enabled = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        inCollision = true;
        GateTXT.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        inCollision = false;
        GateTXT.SetActive(false);
    }
}
