using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackLight : MonoBehaviour
{
    GameObject MainCamera;
    int x = 7, y = -6, X_WaveSize = 3, Y_WaveSize = 0;
    public int LightSize = 3;
    public bool HighQuality = true, IsPause = false;
    bool NowQuality = true;
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
        time += Time.unscaledDeltaTime;
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
        CheckPause();
        float posx = MainCamera.transform.position.x + x + X_WaveSize * Mathf.Sin(time);
        float posy = MainCamera.transform.position.y + y + Y_WaveSize * Mathf.Sin(time);
        gameObject.transform.position = new Vector3(posx, posy, 0);
    }
    void SetQuality()
    {
        if (HighQuality)
        {
            gameObject.GetComponent<HardLight2D>().filteringSettings.layerMask = (1 << 6) | (1 << 7) | (1 << 9) | (1 << 10);
            NowQuality = true;
        }
        else
        {
            gameObject.GetComponent<HardLight2D>().filteringSettings.layerMask = (1 << 6) | (1 << 9);
            NowQuality = false;
        }
    }
    void CheckPause()
    {
        if (nowScene.name.CompareTo("GameScreen") == 0)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (!IsPause)
                {
                    IsPause = true;
                }
            }
        }
    }
}
