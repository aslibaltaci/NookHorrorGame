using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNotes : MonoBehaviour
{
    public Transform[] SpawnPosition;
    //public Transform note;
    private int index;

    // Start is called before the first frame update
    void Start()
    {
        index = Random.Range(0, SpawnPosition.Length);
        transform.position = SpawnPosition[index].transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
