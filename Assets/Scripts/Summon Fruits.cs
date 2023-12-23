using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonFruits : MonoBehaviour
{
    public GameObject Lv1;
    public GameObject Lv2;
    public GameObject Lv3;
    public GameObject Lv4;
    public GameObject Lv5;
    public GameObject Lv6;
    public GameObject Lv7;
    public GameObject Lv8;

    public void Summon(int Lv, Transform tf)
    {
        switch (Lv)
        {
            case 1: Instantiate(Lv1, tf); break;
            case 2: Instantiate(Lv2, tf); break;
            case 3: Instantiate(Lv3, tf); break;
            case 4: Instantiate(Lv4, tf); break;
            case 5: Instantiate(Lv5, tf); break;
            case 6: Instantiate(Lv6, tf); break;
            case 7: Instantiate(Lv7, tf); break;
            case 8: Instantiate(Lv8, tf); break;
            default: break;
        }
    }
}
