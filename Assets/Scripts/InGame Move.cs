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
        Menu.transform.position = new Vector3(4, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseMove)
        {
            Menu.transform.position = Vector3.MoveTowards(Menu.transform.position, new Vector3(0, 0, 0), 10 * Time.unscaledDeltaTime);
            if (Menu.transform.position == new Vector3(0, 0, 0))
            {
                BackLight.GetComponent<BackLight>().CanPause = true;
                PauseMove = false;
            }
        }
        if (BackLight.GetComponent<BackLight>().IsPause && !BackLight.GetComponent<BackLight>().CanPause)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            PauseMove = true;
        }
    }
}
