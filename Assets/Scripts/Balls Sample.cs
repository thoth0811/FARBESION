using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallsSample : MonoBehaviour
{
    public GameObject SpawnPoint;
    public bool isNext = false;
    GameObject Light2D;
    public bool HighQuality = true;
    // Start is called before the first frame update
    void Start()
    {
        SpawnPoint = GameObject.FindWithTag("SpawnPoint");
        SetQuality();
    }

    // Update is called once per frame
    void Update()
    {
        if (isNext)
        {
            gameObject.transform.position = SpawnPoint.transform.position;
        }
    }
    void SetQuality()
    {
        Light2D = transform.GetChild(0).gameObject;

        if (HighQuality)
        {
            Light2D.GetComponent<HardLight2D>().filteringSettings.layerMask = (1 << 6) | (1 << 7) | (1 << 9) | (1 << 10);
        }
        else
        {
            Light2D.GetComponent<HardLight2D>().filteringSettings.layerMask = (1 << 6) | (1 << 9);
        }
    }
}