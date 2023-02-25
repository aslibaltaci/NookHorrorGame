using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockerInteract : MonoBehaviour
{
    public Animator LockerAnim;

    public GameObject LockerUI;
    public GameObject ExitLockerUI;

    public GameObject PlayerCam;
    public GameObject LockerCam;

    public GameObject Player;
    public Transform LockerLoc;

    public EnemyController enemy;

    public AudioSource Audio;
    public AudioClip OpenLocker;
    public AudioClip CloseLocker;


    private bool InsideLocker = false;
    private bool CanInteract = false;

    // Start is called before the first frame update
    void Start()
    {
        LockerCam.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (CanInteract)
        {
            if(Input.GetButtonDown("Interact") && !InsideLocker)
            {
                EnterLocker();
                enemy.playerHidden = true;
            }
            else if (Input.GetButtonDown("Interact") && InsideLocker)
            {
                ExitLocker();
                enemy.playerHidden = false;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        LockerUI.SetActive(true);
        CanInteract = true;
    }

    void OnTriggerExit(Collider other)
    {
        LockerUI.SetActive(false);
        CanInteract = false;
    }

    void EnterLocker()
    {
        ExitLockerUI.SetActive(true);
        LockerUI.SetActive(false);
        PlayerCam.SetActive(false);
        LockerCam.SetActive(true);
        InsideLocker = true;

        LockerAnim.SetBool("EnterLocker?", true);

        Audio.clip = OpenLocker;
        Audio.Play();

        Player.GetComponent<MeshRenderer>().enabled = false;
    }

    void ExitLocker()
    {
        Audio.clip = CloseLocker;
        Audio.Play();

        ExitLockerUI.SetActive(false);
        LockerUI.SetActive(true);
        InsideLocker = false;
        LockerAnim.SetBool("EnterLocker?", false);
        LockerAnim.SetBool("ExitLocker?", true);
        StartCoroutine(ChangeCam());
    }

    IEnumerator ChangeCam()
    {
        yield return new WaitForSeconds(1.2f);
        Player.transform.position = LockerLoc.transform.position;
        PlayerCam.SetActive(true);
        LockerCam.SetActive(false);
        Player.GetComponent<MeshRenderer>().enabled = true;
        StartCoroutine(ResetDoor());
    }

    IEnumerator ResetDoor()
    {
        yield return new WaitForSeconds(1);
        LockerAnim.SetBool("EnterLocker?", false);
        LockerAnim.SetBool("ExitLocker?", false);
    }

}
