using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScore : MonoBehaviour
{
    GameObject SpawnPoint, BackLight;
    int[] ScorePos = { -160, -80, 0, 80, 160};
    public int[] ScoreSolo = {0, 0, 0, 0, 0};
    int Score = 0;
    bool GameOver = false;
    public GameObject Num0, Num1, Num2, Num3, Num4, Num5, Num6, Num7, Num8, Num9;
    // Start is called before the first frame update
    void Start()
    {
        SpawnPoint = GameObject.FindWithTag("SpawnPoint");
        BackLight = GameObject.FindWithTag("BackLight");
    }

    // Update is called once per frame
    void Update()
    {
        if(BackLight.GetComponent<BackLight>().GameOver && !GameOver)
        {
            GameOver = true;
            Score = SpawnPoint.GetComponent<SummonBalls>().Score;
            SpawnNum();
        }
    }
    GameObject SetNum(int num)
    {
        switch (num)
        {
        case 0: return Num0;
        case 1: return Num1;
        case 2: return Num2;
        case 3: return Num3;
        case 4: return Num4;
        case 5: return Num5;
        case 6: return Num6;
        case 7: return Num7;
        case 8: return Num8;
        case 9: return Num9;
        default: return null;
        }
    }
    void NumCut()
    {
        ScoreSolo[0] = (Score) / 10000;
        ScoreSolo[1] = (Score % 10000) / 1000;
        ScoreSolo[2] = (Score % 1000) / 100;
        ScoreSolo[3] = (Score % 100) / 10;
        ScoreSolo[4] = (Score % 10);
    }

    void SpawnNum()
    {
        NumCut();
        GameObject Num = null;
        Vector3 NumSize = new Vector3(1,1,1);
        Num = Instantiate(SetNum(ScoreSolo[0]), new Vector3(ScorePos[0], 0, 0), Quaternion.identity);
        Num.transform.SetParent(this.transform, false);
        Num.transform.localScale = NumSize;
        Num.gameObject.layer = 8;
        Num = Instantiate(SetNum(ScoreSolo[1]), new Vector3(ScorePos[1], 0, 0), Quaternion.identity);
        Num.transform.SetParent(this.transform, false);
        Num.transform.localScale = NumSize;
        Num.gameObject.layer = 8;
        Num = Instantiate(SetNum(ScoreSolo[2]), new Vector3(ScorePos[2], 0, 0), Quaternion.identity);
        Num.transform.SetParent(this.transform, false);
        Num.transform.localScale = NumSize;
        Num.gameObject.layer = 8;
        Num = Instantiate(SetNum(ScoreSolo[3]), new Vector3(ScorePos[3], 0, 0), Quaternion.identity);
        Num.transform.SetParent(this.transform, false);
        Num.transform.localScale = NumSize;
        Num.gameObject.layer = 8;
        Num = Instantiate(SetNum(ScoreSolo[4]), new Vector3(ScorePos[4], 0, 0), Quaternion.identity);
        Num.transform.SetParent(this.transform, false);
        Num.transform.localScale = NumSize;
        Num.gameObject.layer = 8;
    }
}
