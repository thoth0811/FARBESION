using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallsSample : MonoBehaviour
{
    public bool isNext = false;
    GameObject SpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        SpawnPoint = GameObject.FindWithTag("SpawnPoint");
    }

    // Update is called once per frame
    void Update()
    {
        if (isNext)
        {
            gameObject.transform.position = SpawnPoint.transform.position;
        }
    }
}