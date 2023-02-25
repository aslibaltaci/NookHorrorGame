using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
    public Animator PhoneAnim;

    public GameObject Enemy;

    public GameObject Phone;

    public bool canActivate = true;

    public AudioSource Audio;

    public AudioClip Alarm;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Phone") && canActivate)
        {
            canActivate = false;
            PhoneAnim.SetBool("ActivateAlarm", true);
            StartCoroutine(ResetPhone());
            Phone.GetComponent<Percent>().DepletPerecent();
            Enemy.GetComponent<EnemyController>().isStunned = true;

            Audio.clip = Alarm;
            Audio.Play();
        }
    }

    IEnumerator ResetPhone()
    {
        yield return new WaitForSeconds(3);
        PhoneAnim.SetBool("ActivateAlarm", false);
        Enemy.GetComponent<EnemyController>().isStunned = false;
        canActivate = true;
    }
}
