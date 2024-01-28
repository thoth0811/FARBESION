using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    GameObject MainCamera, BackLight, Setting, Mode;
    bool SetBtnOn, BackBtnOn = false;
    Scene nowScene;
    // Start is called before the first frame update
    void Start()
    {
        BackLight = GameObject.FindWithTag("BackLight");
        MainCamera = GameObject.FindWithTag("MainCamera");
        Setting = GameObject.FindWithTag("Setting");
        Mode = GameObject.FindWithTag("Mode");
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
        Setting.transform.position = new Vector3(0, -12, 0);
        Mode.transform.position = new Vector3(0, -24, 0);
        SetBtnOn = true;
    }
    public void ModeButton()
    {
        BackLight.GetComponent<BackLight>().BTNClick.Play();
        Setting.transform.position = new Vector3(0, -24, 0);
        Mode.transform.position = new Vector3(0, -12, 0);
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
    public void RandomBall()
    {
        BackLight.GetComponent<BackLight>().BTNClick.Play();
        BackLight.GetComponent<BackLight>().Unknown = !BackLight.GetComponent<BackLight>().Unknown;
    }
    public void RandomPosition()
    {
        BackLight.GetComponent<BackLight>().BTNClick.Play();
        BackLight.GetComponent<BackLight>().RandomPos = !BackLight.GetComponent<BackLight>().RandomPos;
    }
    public void RandomMerge()
    {
        BackLight.GetComponent<BackLight>().BTNClick.Play();
        BackLight.GetComponent<BackLight>().RandomMerge = !BackLight.GetComponent<BackLight>().RandomMerge;
    }
    public void MiniBall()
    {
        BackLight.GetComponent<BackLight>().BTNClick.Play();
        BackLight.GetComponent<BackLight>().Mini = !BackLight.GetComponent<BackLight>().Mini;
    }
    public void PopcornWorld()
    {
        BackLight.GetComponent<BackLight>().BTNClick.Play();
        if (BackLight.GetComponent<BackLight>().PopPower == 0.5f)
        {
            BackLight.GetComponent<BackLight>().PopPower = 5f;
        }
        else
        {
            BackLight.GetComponent<BackLight>().PopPower = 0.5f;
        }
    }
}
