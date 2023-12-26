using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowScore : MonoBehaviour
{
    public TextMeshProUGUI Score;
    GameObject SpawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        SpawnPoint = GameObject.FindWithTag("SpawnPoint");
    }

    // Update is called once per frame
    void Update()
    {
        Score.text = string.Format($"Score : {SpawnPoint.GetComponent<SummonBalls>().Score}");
    }
}
