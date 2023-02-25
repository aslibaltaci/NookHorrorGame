using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform player;
    public Transform Des;
    public GameObject PlayerRB;

    public GameObject TeleportUI;

    public bool Colliding = false;

    private void Update()
    {
        if (Input.GetButtonDown("Interact") && Colliding)
        {
            BeginTP();
        }
    }
    void OnTriggerEnter(Collider other)
    {
            TeleportUI.SetActive(true);
            Colliding = true;

    }

    void OnTriggerExit(Collider other)
    {
            TeleportUI.SetActive(false);
            Colliding = false;
    }

    void BeginTP()
    {
        PlayerRB.SetActive(false);
        player.position = Des.position;
        PlayerRB.SetActive(true);

        Colliding = false;
        TeleportUI.SetActive(false);
    }
}
