using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMove : MonoBehaviour
{
    GameObject Menu, BackLight;
    bool PauseMove = false;
    // Start is called before the first frame update
    void Start()
    {
        Menu = GameObject.FindWithTag("Pause Menu");
        BackLight = GameObject.FindWithTag("BackLight");
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseMove)
        {
            Menu.transform.position = Vector3.MoveTowards(Menu.transform.position, new Vector3(0, 0, 0), 40 * Time.unscaledDeltaTime);
            if (Menu.transform.position == new Vector3(0, 0, 0))
            {
                PauseMove = false;
            }
        }
        if (BackLight.GetComponent<BackLight>().IsPause)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            PauseMove = true;
        }
    }
}
