using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextOcclusion : MonoBehaviour
{
    GameObject MainCamera;
    PolygonCollider2D poly;
    TMP_Text tmp;
    bool CollOn;

    // Start is called before the first frame update
    void Start()
    {
        MainCamera = GameObject.FindWithTag("MainCamera");
        poly = gameObject.GetComponent<PolygonCollider2D>();
        tmp = gameObject.GetComponent<TMP_Text>();
        if (Mathf.Abs(gameObject.transform.position.x - MainCamera.transform.position.x) < 16 && Mathf.Abs(gameObject.transform.position.y - MainCamera.transform.position.y) < 7)
        {
            CollOn = true;
        }
        else
        {
            CollOn = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Abs(gameObject.transform.position.x - MainCamera.transform.position.x) < 16 && Mathf.Abs(gameObject.transform.position.y - MainCamera.transform.position.y) < 7)
        {
            CollOn = true;
        }
        else
        {
            CollOn = false;
        }

        if(poly.enabled == true && CollOn == false)
        {
            poly.enabled = false;
            tmp.enabled = false;
        }
        if(poly.enabled == false &&  CollOn == true)
        {
            poly.enabled = true;
            tmp.enabled = true;
        }
    }
}
