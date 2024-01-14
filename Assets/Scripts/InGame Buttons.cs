using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameButtons : MonoBehaviour
{
    GameObject Menu, PauseText, BackLight, GameOver;
    bool PauseMove = false;
    // Start is called before the first frame update
    void Start()
    {
        BackLight = GameObject.FindWithTag("BackLight");
        PauseText = GameObject.FindWithTag("Paused Text");
        Menu = GameObject.FindWithTag("Pause Menu");
        GameOver = GameObject.FindWithTag("GameOver");
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseMove)
        {
            Menu.transform.position = Vector3.MoveTowards(Menu.transform.position, new Vector3(4, 0, 0), 10 * Time.unscaledDeltaTime);
            if (Menu.transform.position == new Vector3(4, 0, 0))
            {
                BackLight.GetComponent<BackLight>().CanPause = true;
                PauseMove = false;
            }
        }
        if (BackLight.GetComponent<BackLight>().GameOver)
        {
            GameOver.transform.position = Vector3.MoveTowards(GameOver.transform.position, new Vector3(0, 0, 0), 0.5f * Time.unscaledDeltaTime);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (BackLight.GetComponent<BackLight>().IsPause && BackLight.GetComponent<BackLight>().CanPause)
            {
                BackLight.GetComponent<BackLight>().CanPause = false;
                BackLight.GetComponent<BackLight>().IsPause = false;
                PauseText.transform.GetChild(0).gameObject.SetActive(false);
                PauseMove = true;
            }
        }
    }
    public void ResumeButton()
    {
        if (BackLight.GetComponent<BackLight>().IsPause && BackLight.GetComponent<BackLight>().CanPause)
        {
            BackLight.GetComponent<BackLight>().CanPause = false;
            BackLight.GetComponent<BackLight>().IsPause = false;
            PauseText.transform.GetChild(0).gameObject.SetActive(false);
            PauseMove = true;
        }
    }
    public void ExitButton()
    {
        SceneManager.LoadScene("MainScreen");
    }
    public void NewGameButton()
    {
        SceneManager.LoadScene("GameLoadingScreen");
    }
}
