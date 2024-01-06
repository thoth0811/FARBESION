using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public GameObject CanvasGroup, BackLight;
    public float time = 1.0f;
    bool SetBtnOn, BackBtnOn = false;
    // Start is called before the first frame update
    void Start()
    {
        BackLight = GameObject.FindWithTag("BackLight");
        CanvasGroup = GameObject.FindWithTag("CanvasGroup");
    }

    // Update is called once per frame
    void Update()
    {
        if (SetBtnOn)
        {
            CanvasGroup.transform.position = Vector3.MoveTowards(CanvasGroup.transform.position, new Vector3(0, 12, 0), (12 / time) * Time.deltaTime);
            if (CanvasGroup.transform.position == new Vector3(0, 12, 0))
            {
                SetBtnOn = false;
            }
        }
        if (BackBtnOn)
        {
            CanvasGroup.transform.position = Vector3.MoveTowards(CanvasGroup.transform.position, new Vector3(0, 0, 0), (12 / time) * Time.deltaTime);
            if (CanvasGroup.transform.position == new Vector3(0, 0, 0))
            {
                BackBtnOn = false;
            }
        }
    }

    public void StartButton()
    {
        SceneManager.LoadScene("GameScreen");
    }

    public void SettingButton()
    {
        SetBtnOn = true;
    }
    public void ExitButton()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }
    public void BackButton()
    {
        BackBtnOn = true;
    }
    public void HIGHButton()
    {
        BackLight.GetComponent<BackLight>().HighQuality = true;
    }
    public void LOWButton()
    {
        BackLight.GetComponent<BackLight>().HighQuality = false;
    }
}
