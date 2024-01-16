using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackLight : MonoBehaviour
{
    GameObject MainCamera;
    public int LightSize = 3;
    public bool HighQuality = true, IsPause = false, CanPause = true, BLMoveOn = true, GameOver = false;
    bool NowQuality = false;
    float time = 0f;
    Scene nowScene;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        MainCamera = GameObject.FindWithTag("MainCamera");
        nowScene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        if(BLMoveOn)
        {
            time += Time.unscaledDeltaTime;
        }
        if (nowScene != SceneManager.GetActiveScene())
        {
            nowScene = SceneManager.GetActiveScene();
        }

        if (NowQuality != HighQuality)
        {
            SetQuality();
        }
        if (nowScene.name.CompareTo("LoadingScreen") == 0)
        {
            SceneManager.LoadScene("MainScreen");
        }
        if (nowScene.name.CompareTo("GameLoadingScreen") == 0)
        {
            GameOver = false;
            SceneManager.LoadScene("GameScreen");
        }
        CheckPause();
        LightMove();
    }
    void SetQuality()
    {
        if (HighQuality)
        {
            gameObject.GetComponent<HardLight2D>().filteringSettings.layerMask = (1 << 6) | (1 << 7) | (1 << 8) | (1 << 9) | (1 << 10);
            NowQuality = true;
        }
        else
        {
            gameObject.GetComponent<HardLight2D>().filteringSettings.layerMask = (1 << 6) | (1 << 8) | (1 << 9);
            NowQuality = false;
        }
    }
    void CheckPause()
    {
        if (nowScene.name.CompareTo("GameScreen") == 0)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (!IsPause && CanPause)
                {
                    IsPause = true;
                    CanPause = false;
                }
            }
        }
    }
    void LightMove()
    {
        if( 0 < time  && time <= 12)
        {
            gameObject.transform.position = MainCamera.transform.position + new Vector3(11f, time - 6f, 0);
        }
        if( 12 < time  && time <= 34)
        {
            gameObject.transform.position = MainCamera.transform.position + new Vector3(23f - time, 6f, 0);
        }
        if( 34 < time  && time <= 46)
        {
            gameObject.transform.position = MainCamera.transform.position + new Vector3(-11f, 40f - time, 0);
        }
        if( 46 < time  && time <= 68)
        {
            gameObject.transform.position = MainCamera.transform.position + new Vector3(time - 57f, -6f, 0);
        }
        if(time > 68)
        {
            time = 0;
        }
    }
}
