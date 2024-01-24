using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackLight : MonoBehaviour
{
    GameObject MainCamera;
    public int LightSize = 3;
    public bool HighQuality = true, IsPause = false, CanPause = true, BLMoveOn = true, GameOver = false, MousePlay = false;
    public bool NowQuality = false, BGMPlaying = false, WarningOn = false;
    public bool Unknown = false, RandomPos = false, Mini = false, RandomMerge = false;
    public float time = 0f, WarnTime, PopPower = 0.5f;
    public AudioSource BGM, BTNClick;
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
        if (nowScene.name.CompareTo("MainScreen") == 0)
        {
            GameOver = false;
            WarningOn = false;
        }
        if (BGMPlaying && GameOver)
        {
            BGMPlaying = false;
            BGM.Stop();
        }
        if (!BGMPlaying && !GameOver)
        {
            BGMPlaying = true;
            BGM.Play();
        }
        CheckPause();
        LightMove();
        Warning();
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
    void Warning()
    {
        float HighestBall = 0;
        if (WarningOn)
        {
            if(WarnTime < 1f)
            {
                WarnTime += Time.unscaledDeltaTime * 2;
            }
        }
        else
        {
            if (WarnTime > 0f)
            {
                WarnTime -= Time.unscaledDeltaTime * 2;
            }
        }
        GameObject[] GameBalls = GameObject.FindGameObjectsWithTag("Balls");
        if( GameBalls == null)
        {
            HighestBall = 0;
        }
        else
        {
            foreach (GameObject ball in GameBalls)
            {
                if (ball.GetComponent<Balls>().CheckWarning)
                {
                    float BallHigh = ball.transform.position.y + 0.15f * ball.GetComponent<Balls>().Level;
                    if (BallHigh > HighestBall)
                    {
                        HighestBall = BallHigh;
                    }
                }
            }
        }

        if (HighestBall > 2.5f && !WarningOn)
        {
            WarningOn = true;
        }
        else if (HighestBall <= 2.5f && WarningOn)
        {
            WarningOn = false;
        }
        gameObject.GetComponent<HardLight2D>().Color = new Color(1f, Mathf.Lerp(1f,0f,WarnTime), Mathf.Lerp(1f, 0f, WarnTime));
        gameObject.GetComponent<HardLight2D>().Color.a = 0.3f;
    }
}
