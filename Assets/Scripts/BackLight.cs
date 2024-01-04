using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackLight : MonoBehaviour
{
    public int x, y, X_WaveSize, Y_WaveSize;
    GameObject Light2D;
    public bool HighQuality = true;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        SetQuality();
    }

    // Update is called once per frame
    void Update()
    {
        Scene nowScene = SceneManager.GetActiveScene();

        switch (nowScene.name)
        {
            case "LoadingScreen":
                SceneManager.LoadScene("MainScreen");
                break;
        }
        gameObject.transform.position = new Vector3(x + X_WaveSize * Mathf.Sin(Time.time), y + Y_WaveSize * Mathf.Sin(Time.time), 0);
    }
    void SetQuality()
    {
        Light2D = transform.GetChild(0).gameObject;

        if (HighQuality)
        {
            Light2D.GetComponent<HardLight2D>().filteringSettings.layerMask = (1 << 6) | (1 << 7) | (1 << 9) | (1 << 10);
        }
        else
        {
            Light2D.GetComponent<HardLight2D>().filteringSettings.layerMask = (1 << 6) | (1 << 9);
        }
    }
}
