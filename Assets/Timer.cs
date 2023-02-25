using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{

    public TextMeshProUGUI Timetext;

    public GameObject GameController;

    private float totalTime;

    // Start is called before the first frame update
    void Start()
    {
        totalTime = GameController.GetComponent<GameController>().timer;
    }

    // Update is called once per frame
    void Update()
    {
        Timetext.text = totalTime.ToString();
    }
}
