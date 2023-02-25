using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LockInteraction : MonoBehaviour
{

    public GameObject LeftLock;
    public GameObject RightLock;
    public GameObject MiddleLock;

    public bool LeftAcitve = true;
    public bool RightAcitve = false;
    public bool MiddleAcitve = false;

    public TextMeshProUGUI NumTXT;
    public TextMeshProUGUI NumTXTM;
    public TextMeshProUGUI NumTXTR;

    private int CodeNUM;
    private int CodeNUMMiddle;
    private int CodeNUMRight;

    public AudioSource Audio;
    public AudioClip LockSwitch;

    private bool OptionChange = false;

    private bool LockChange = false;

    // Start is called before the first frame update
    void Start()
    {
        CodeNUM = 0;

        CodeNUMMiddle = 0;

        CodeNUMRight = 0;
    }

    // Update is called once per frame
    void Update()
    {
        print(CodeNUM);
        NumTXT.text = CodeNUM.ToString();

        NumTXTM.text = CodeNUMMiddle.ToString();

        NumTXTR.text = CodeNUMRight.ToString();

        if (Input.GetAxis("LockValue") == 0)
        {
            OptionChange = false;
        }

        if (Input.GetAxis("ChangeLock") == 0)
        {
            LockChange = false;
        }

        //LeftLock
        if (LeftAcitve)
        {
            LockL();
            LeftLock.GetComponent<Image>().color = Color.yellow;
        }
        else
        {
            LeftLock.GetComponent<Image>().color = Color.white;
        }

        //MiddleLock
        if (MiddleAcitve)
        {
            LockM();
            MiddleLock.GetComponent<Image>().color = Color.yellow;
        }
        else
        {
            MiddleLock.GetComponent<Image>().color = Color.white;
        }

        //RightLock
        if (RightAcitve)
        {
            LockR();
            RightLock.GetComponent<Image>().color = Color.yellow;
        }
        else
        {
            RightLock.GetComponent<Image>().color = Color.white;
        }
    }

    void LockL()
    {
        if (LeftAcitve)
        {
            if (Input.GetAxis("LockValue") > 0 && !OptionChange)
            {
                OptionChange = true;

                FlipLock();

                if (CodeNUM == 9)
                {
                    CodeNUM = 0;
                }
                else
                {
                    CodeNUM += 1;
                }
            }
            else if (Input.GetAxis("LockValue") < 0 && !OptionChange)
            {
                OptionChange = true;

                FlipLock();

                if (CodeNUM == 0)
                {
                    CodeNUM = 9;
                }
                else
                {
                    CodeNUM -= 1;
                }
            }

            //going to the right option
            if (Input.GetAxis("ChangeLock") > 0 && !LockChange)
            {

                LockChange = true;

                LeftAcitve = false;
                MiddleAcitve = true;
                RightAcitve = false;
            }
            //going to the left option
            if (Input.GetAxis("ChangeLock") < 0 && !LockChange)
            {
                LockChange = true;

                LeftAcitve = false;
                MiddleAcitve = false;
                RightAcitve = true;
            }
        }
    }

    void LockM()
    {
        if (MiddleAcitve)
        {
            if (Input.GetAxis("LockValue") > 0 && !OptionChange)
            {
                OptionChange = true;

                FlipLock();

                if (CodeNUMMiddle == 9)
                {
                    CodeNUMMiddle = 0;
                }
                else
                {
                    CodeNUMMiddle += 1;
                }
            }
            else if (Input.GetAxis("LockValue") < 0 && !OptionChange)
            {
                OptionChange = true;

                FlipLock();

                if (CodeNUMMiddle == 0)
                {
                    CodeNUMMiddle = 9;
                }
                else
                {
                    CodeNUMMiddle -= 1;
                }
            }

            //going to the right option
            if (Input.GetAxis("ChangeLock") > 0 && !LockChange)
            {
                LockChange = true;

                LeftAcitve = false;
                MiddleAcitve = false;
                RightAcitve = true;

               
            }
            //going to the left option
            else if (Input.GetAxis("ChangeLock") < 0 && !LockChange)
            {
                LockChange = true;

                LeftAcitve = true;
                MiddleAcitve = false;
                RightAcitve = false;
            }
        }
    }

    void LockR()
    {
        if (RightAcitve)
        {
            if (Input.GetAxis("LockValue") > 0 && !OptionChange)
            {
                OptionChange = true;

                FlipLock();

                if (CodeNUMRight == 9)
                {
                    CodeNUMRight = 0;
                }
                else
                {
                    CodeNUMRight += 1;
                }
            }
            else if (Input.GetAxis("LockValue") < 0 && !OptionChange)
            {
                OptionChange = true;

                FlipLock();

                if (CodeNUMRight == 0)
                {
                    CodeNUMRight = 9;
                }
                else
                {
                    CodeNUMRight -= 1;
                }
            }

            //going to the right option
            if (Input.GetAxis("ChangeLock") > 0 && !LockChange)
            {
                LockChange = true;

                LeftAcitve = true;
                MiddleAcitve = false;
                RightAcitve = false;
            }
            //going to the left option
            else if (Input.GetAxis("ChangeLock") < 0 && !LockChange)
            {
                LockChange = true;

                LeftAcitve = false;
                MiddleAcitve = true;
                RightAcitve = false;
            }
        }
    }

    void FlipLock()
    {
        Audio.clip = LockSwitch;
        Audio.Play();
    }
}
