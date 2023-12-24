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
    public GameObject Lv9;
    public GameObject Lv10;
    public GameObject Lv11;

    public void Summon(int Lv, Vector3 vec)
    {
        switch (Lv)
        {
            case 1: Instantiate(Lv1, vec, Quaternion.identity); break;
            case 2: Instantiate(Lv2, vec, Quaternion.identity); break;
            case 3: Instantiate(Lv3, vec, Quaternion.identity); break;
            case 4: Instantiate(Lv4, vec, Quaternion.identity); break;
            case 5: Instantiate(Lv5, vec, Quaternion.identity); break;
            case 6: Instantiate(Lv6, vec, Quaternion.identity); break;
            case 7: Instantiate(Lv7, vec, Quaternion.identity); break;
            case 8: Instantiate(Lv8, vec, Quaternion.identity); break;
            case 9: Instantiate(Lv9, vec, Quaternion.identity); break;
            case 10: Instantiate(Lv10, vec, Quaternion.identity); break;
            case 11: Instantiate(Lv11, vec, Quaternion.identity); break;
            default: break;
        }
    }
}
