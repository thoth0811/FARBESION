using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallQuality : MonoBehaviour
{
    bool HighQuality = true;
    GameObject BackLight, Light2D;
    
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
            SetQuality(BackLight.GetComponent<BackLight>().HighQuality);
        }
        if(Light2D.GetComponent<HardLight2D>().Range != BackLight.GetComponent<BackLight>().LightSize)
        {
            Light2D.GetComponent<HardLight2D>().Range = BackLight.GetComponent<BackLight>().LightSize;
        }
    }

    void SetQuality(bool Q)
    {
        if (Q)
        {
            Light2D.GetComponent<HardLight2D>().filteringSettings.layerMask = (1 << 6) | (1 << 7) | (1 << 9) | (1 << 10);
            HighQuality = true;
        }
        else
        {
            Light2D.GetComponent<HardLight2D>().filteringSettings.layerMask = (1 << 6) | (1 << 9);
            HighQuality = false;
            HighQuality = false;
        }
    }
}
