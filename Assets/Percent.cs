using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Percent : MonoBehaviour
{
    public GameObject Player;

    public TextMeshProUGUI Text;

    public int percent = 100;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Text.text = percent.ToString();

    }

    public void DepletPerecent()
    {
        percent -= 10;
    }
}
