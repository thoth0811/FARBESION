using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallQuality : MonoBehaviour
{
    bool HighQuality = true;
    GameObject BackLight;
    GameObject Light2D;
    // Start is called before the first frame update
    void Start()
    {
        BackLight = GameObject.FindWithTag("BackLight");
        Light2D = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (HighQuality != BackLight.GetComponent<BackLight>().HighQuality)
        {
            SetQuality(false);
        }
    }

    void SetQuality(bool Q)
    {
        if (Q)
        {
            Light2D.GetComponent<HardLight2D>().filteringSettings.layerMask = (1 << 6) | (1 << 7) | (1 << 9) | (1 << 10);
        }
        else
        {
            Light2D.GetComponent<HardLight2D>().filteringSettings.layerMask = (1 << 6) | (1 << 9);
        }
    }
}
