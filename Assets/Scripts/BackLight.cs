using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackLight : MonoBehaviour
{
    GameObject MainCamera;
    public int x, y, X_WaveSize, Y_WaveSize;
    public bool HighQuality = true;
    public int LightSize = 3;
    bool NowQuality = true;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        MainCamera = GameObject.FindWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        Scene nowScene = SceneManager.GetActiveScene();

        if(NowQuality != HighQuality)
        {
            SetQuality();
        }  
        switch (nowScene.name)
        {
            case "LoadingScreen":
                SceneManager.LoadScene("MainScreen");
                break;
        }
        gameObject.transform.position = new Vector3(MainCamera.transform.position.x + x + X_WaveSize * Mathf.Sin(Time.time), MainCamera.transform.position.y + y + Y_WaveSize * Mathf.Sin(Time.time), 0);
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
}
