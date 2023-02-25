using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Lock : MonoBehaviour
{
    public TextMeshProUGUI NumTXT;
    public TextMeshProUGUI NumTXTM;
    public TextMeshProUGUI NumTXTR;

    private int CodeNUM;
    private int CodeNUMMiddle;
    private int CodeNUMRight;

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
        NumTXT.text = CodeNUM.ToString();

        NumTXTM.text = CodeNUMMiddle.ToString();

        NumTXTR.text = CodeNUMRight.ToString();
    }

    public void ValueUp()
    {
        if (CodeNUM == 9)
        {
            CodeNUM = 0;
        }
        else
        {
            CodeNUM += 1;
        }
    }

    public void ValueDown()
    {
        if (CodeNUM == 0)
        {
            CodeNUM = 9;
        }
        else
        {
            CodeNUM -= 1;
        }
    }

    public void ValueUpM()
    {
        if (CodeNUMMiddle == 9)
        {
            CodeNUMMiddle = 0;
        }
        else
        {
            CodeNUMMiddle += 1;
        }
    }

    public void ValueDownM()
    {
        if (CodeNUMMiddle == 0)
        {
            CodeNUMMiddle = 9;
        }
        else
        {
            CodeNUMMiddle -= 1;
        }
    }

    public void ValueUpR()
    {
        if (CodeNUMRight == 9)
        {
            CodeNUMRight = 0;
        }
        else
        {
            CodeNUMRight += 1;
        }
    }

    public void ValueDownR()
    {
        if (CodeNUMRight == 0)
        {
            CodeNUMRight = 9;
        }
        else
        {
            CodeNUMRight -= 1;
        }
    }
}
