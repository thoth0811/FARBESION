using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowScore : MonoBehaviour
{
    GameObject SpawnPoint;
    int[] ScorePos = {330, 400, 470, 540, 610};
    int[] Score_Solo = {0, 0, 0, 0, 0};
    int Score;
    public GameObject Num0, Num1, Num2, Num3, Num4, Num5, Num6, Num7, Num8, Num9;
    // Start is called before the first frame update
    void Start()
    {
        SpawnPoint = GameObject.FindWithTag("SpawnPoint");
    }

    // Update is called once per frame
    void Update()
    {
        if(Score != SpawnPoint.GetComponent<SummonBalls>().Score)
        {
            Score = SpawnPoint.GetComponent<SummonBalls>().Score;
        }
    }

    public void ClearNums()
    {
        GameObject[] GameNums = GameObject.FindGameObjectsWithTag("Number");
        foreach (GameObject num in GameNums)
        {
            Destroy(num, 0f);
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
        Score_Solo[0] = (Score) / 10000;
        Score_Solo[1] = (Score % 10000) / 1000;
        Score_Solo[2] = (Score % 1000) / 100;
        Score_Solo[3] = (Score % 100) / 10;
        Score_Solo[4] = (Score % 10);
    }
}
