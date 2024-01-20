using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    GameObject MainCamera, BackLight;
    bool SetBtnOn, BackBtnOn = false;
    Scene nowScene;
    // Start is called before the first frame update
    void Start()
    {
        BackLight = GameObject.FindWithTag("BackLight");
        MainCamera = GameObject.FindWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        if (SetBtnOn)
        {
            MainCamera.transform.position = Vector3.MoveTowards(MainCamera.transform.position, new Vector3(0, -12, -10), 12 * Time.unscaledDeltaTime);
            if (MainCamera.transform.position == new Vector3(0, -12, -10))
            {
                SetBtnOn = false;
            }
        }
        if (BackBtnOn)
        {
            MainCamera.transform.position = Vector3.MoveTowards(MainCamera.transform.position, new Vector3(0, 0, -10), 12 * Time.unscaledDeltaTime);
            if (MainCamera.transform.position == new Vector3(0, 0, -10))
            {
                BackBtnOn = false;
            }
        }
    }

    public void StartButton()
    {
        BackLight.GetComponent<BackLight>().BTNClick.Play();
        SceneManager.LoadScene("GameLoadingScreen");
    }

    public void SettingButton()
    {
        BackLight.GetComponent<BackLight>().BTNClick.Play();
        SetBtnOn = true;
    }
    public void ExitButton()
    {
        BackLight.GetComponent<BackLight>().BTNClick.Play();
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
        #endif
    }
    public void BackButton()
    {
        BackLight.GetComponent<BackLight>().BTNClick.Play();
        BackBtnOn = true;
    }
    public void HIGHButton()
    {
        BackLight.GetComponent<BackLight>().BTNClick.Play();
        BackLight.GetComponent<BackLight>().HighQuality = true;
    }
    public void LOWButton()
    {
        BackLight.GetComponent<BackLight>().BTNClick.Play();
        BackLight.GetComponent<BackLight>().HighQuality = false;
    }
    public void _3Button()
    {
        BackLight.GetComponent<BackLight>().BTNClick.Play();
        BackLight.GetComponent<BackLight>().LightSize = 3;
    }
    public void _5Button()
    {
        BackLight.GetComponent<BackLight>().BTNClick.Play();
        BackLight.GetComponent<BackLight>().LightSize = 5;
    }
    public void _7Button()
    {
        BackLight.GetComponent<BackLight>().BTNClick.Play();
        BackLight.GetComponent<BackLight>().LightSize = 7;
    }
    public void OnButton()
    {
        BackLight.GetComponent<BackLight>().BTNClick.Play();
        BackLight.GetComponent<BackLight>().BLMoveOn = true;
    }
    public void OffButton()
    {
        BackLight.GetComponent<BackLight>().BTNClick.Play();
        BackLight.GetComponent<BackLight>().BLMoveOn = false;
    }
    public void MouseButton()
    {
        BackLight.GetComponent<BackLight>().BTNClick.Play();
        BackLight.GetComponent<BackLight>().MousePlay = true;
    }
    public void KeyboardButton()
    {
        BackLight.GetComponent<BackLight>().BTNClick.Play();
        BackLight.GetComponent<BackLight>().MousePlay = false;
    }
}
