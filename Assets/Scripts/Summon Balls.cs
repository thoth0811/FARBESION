using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonBalls : MonoBehaviour
{
    public GameObject Lv1s, Lv2s, Lv3s, Lv4s, Lv1, Lv2, Lv3, Lv4, Lv5, Lv6, Lv7, Lv8, Lv9, Lv10, Lv11;
    public List<GameObject> LLv1s = new List<GameObject>(), LLv2s = new List<GameObject>(), LLv3s = new List<GameObject>(), LLv4s = new List<GameObject>(), LLv1 = new List<GameObject>(), LLv2 = new List<GameObject>(), LLv3 = new List<GameObject>(), LLv4 = new List<GameObject>(), LLv5 = new List<GameObject>(), LLv6 = new List<GameObject>(), LLv7 = new List<GameObject>(), LLv8 = new List<GameObject>(), LLv9 = new List<GameObject>(), LLv10 = new List<GameObject>(), LLv11 = new List<GameObject>();
    public int Score = 0;
    int Lv1n = 10, Lv2n = 10, Lv3n = 10, Lv4n = 10, Lv5n = 10, Lv6n = 8, Lv7n = 8, Lv8n = 6, Lv9n = 6, Lv10n = 4, Lv11n = 4;
    float SpawnCool = 0.7f, NextSpawn = 0, time = 0;
    Queue<int> NextBallsNum = new Queue<int>(3);
    int[] NextBall = new int[3];
    bool isSampleSpawn = false, GameOver = false;
    GameObject Ball, BackLight;
    // Start is called before the first frame update
    void Start()
    {
        PrefebPools();
        BackLight = GameObject.FindWithTag("BackLight");
        NextBallsNum.Enqueue(Random.Range(1, 5));
        NextBallsNum.Enqueue(Random.Range(1, 5));
        NextBallsNum.Enqueue(Random.Range(1, 5));
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 1.0f  && BackLight.GetComponent<BackLight>().IsPause && !GameOver)
        {
            Time.timeScale = 0f;
        }
        if (BackLight.GetComponent<BackLight>().GameOver && !GameOver)
        {
            GameOver = true;
            Time.timeScale = 0f;
        }
        if (!BackLight.GetComponent<BackLight>().IsPause && !GameOver)
        {
            Time.timeScale = 1.0f;
            time += Time.deltaTime;
            if (!isSampleSpawn)
            {
                SpawnSample();
            }
            KeyInput();
        }    
    }
    void RemoveSample()
    {
        GameObject[] GameBalls = GameObject.FindGameObjectsWithTag("BallSample");
        foreach (GameObject ball in GameBalls)
        {
            ball.SetActive(false);
        }

        isSampleSpawn = false;
    }
    public void Summon(int Lv, Vector3 pos)
    {
        switch (Lv)
        {
            case 1:
                {
                    Ball = GetPooledObject("1");
                    if (Ball != null)
                    {
                        Ball.transform.position = pos;
                        Ball.SetActive(true);
                    }
                    break;
                }
            case 2:
                {
                    Ball = GetPooledObject("2");
                    if (Ball != null)
                    {
                        Ball.transform.position = pos;
                        Ball.SetActive(true);
                    }
                    break;
                }
            case 3:
                {
                    Ball = GetPooledObject("3");
                    if (Ball != null)
                    {
                        Ball.transform.position = pos;
                        Ball.SetActive(true);
                    }
                    break;
                }
            case 4:
                {
                    Ball = GetPooledObject("4");
                    if (Ball != null)
                    {
                        Ball.transform.position = pos;
                        Ball.SetActive(true);
                    }
                    break;
                }
            case 5:
                {
                    Ball = GetPooledObject("5");
                    if (Ball != null)
                    {
                        Ball.transform.position = pos;
                        Ball.SetActive(true);
                    }
                    break;
                }
            case 6:
                {
                    Ball = GetPooledObject("6");
                    if (Ball != null)
                    {
                        Ball.transform.position = pos;
                        Ball.SetActive(true);
                    }
                    break;
                }
            case 7:
                {
                    Ball = GetPooledObject("7");
                    if (Ball != null)
                    {
                        Ball.transform.position = pos;
                        Ball.SetActive(true);
                    }
                    break;
                }
            case 8:
                {
                    Ball = GetPooledObject("8");
                    if (Ball != null)
                    {
                        Ball.transform.position = pos;
                        Ball.SetActive(true);
                    }
                    break;
                }
            case 9:
                {
                    Ball = GetPooledObject("9");
                    if (Ball != null)
                    {
                        Ball.transform.position = pos;
                        Ball.SetActive(true);
                    }
                    break;
                }
            case 10:
                {
                    Ball = GetPooledObject("10");
                    if (Ball != null)
                    {
                        Ball.transform.position = pos;
                        Ball.SetActive(true);
                    }
                    break;
                }
            case 11:
                {
                    Ball = GetPooledObject("11");
                    if (Ball != null)
                    {
                        Ball.transform.position = pos;
                        Ball.SetActive(true);
                    }
                    break;
                }
            default: break;
        }
    }
    void SpawnSample()
    {
        isSampleSpawn = true;
        NextBallsNum.Enqueue(Random.Range(1, 5));
        NextBall = NextBallsNum.ToArray();
        switch (NextBall[0])
        {
            case 1:
                {
                    Ball = GetPooledObject("1s");
                    if (Ball != null)
                    {
                        Ball.transform.position = gameObject.transform.position;
                        Ball.SetActive(true);
                    }
                    break;
                }
            case 2:
                {
                    Ball = GetPooledObject("2s");
                    if (Ball != null)
                    {
                        Ball.transform.position = gameObject.transform.position;
                        Ball.SetActive(true);
                    }
                    break;
                }
            case 3:
                {
                    Ball = GetPooledObject("3s");
                    if (Ball != null)
                    {
                        Ball.transform.position = gameObject.transform.position;
                        Ball.SetActive(true);
                    }
                    break;
                }
            case 4:
                {
                    Ball = GetPooledObject("4s");
                    if (Ball != null)
                    {
                        Ball.transform.position = gameObject.transform.position;
                        Ball.SetActive(true);
                    }
                    break;
                }
            default: break;
        }
        Ball.gameObject.GetComponent<BallsSample>().isNext = true;
        switch (NextBall[1])
        {
            case 1:
                {
                    Ball = GetPooledObject("1s");
                    if (Ball != null)
                    {
                        Ball.transform.position = new Vector3(-5, 4.5f, 0);
                        Ball.SetActive(true);
                    }
                    break;
                }
            case 2:
                {
                    Ball = GetPooledObject("2s");
                    if (Ball != null)
                    {
                        Ball.transform.position = new Vector3(-5, 4.5f, 0);
                        Ball.SetActive(true);
                    }
                    break;
                }
            case 3:
                {
                    Ball = GetPooledObject("3s");
                    if (Ball != null)
                    {
                        Ball.transform.position = new Vector3(-5, 4.5f, 0);
                        Ball.SetActive(true);
                    }
                    break;
                }
            case 4:
                {
                    Ball = GetPooledObject("4s");
                    if (Ball != null)
                    {
                        Ball.transform.position = new Vector3(-5, 4.5f, 0);
                        Ball.SetActive(true);
                    }
                    break;
                }
            default: break;          
        }
        Ball.gameObject.GetComponent<BallsSample>().isNext = false;
        switch (NextBall[2])         
        {                            
            case 1:
                {
                    Ball = GetPooledObject("1s");
                    if (Ball != null)
                    {
                        Ball.transform.position = new Vector3(-7, 4.5f, 0);
                        Ball.SetActive(true);
                    }
                    break;
                }
            case 2:
                {
                    Ball = GetPooledObject("2s");
                    if (Ball != null)
                    {
                        Ball.transform.position = new Vector3(-7, 4.5f, 0);
                        Ball.SetActive(true);
                    }
                    break;
                }
            case 3:
                {
                    Ball = GetPooledObject("3s");
                    if (Ball != null)
                    {
                        Ball.transform.position = new Vector3(-7, 4.5f, 0);
                        Ball.SetActive(true);
                    }
                    break;
                }
            case 4:
                {
                    Ball = GetPooledObject("4s");
                    if (Ball != null)
                    {
                        Ball.transform.position = new Vector3(-7, 4.5f, 0);
                        Ball.SetActive(true);
                    }
                    break;
                }
            default: break;
        }
        Ball.gameObject.GetComponent<BallsSample>().isNext = false;
    }
    void KeyInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (NextSpawn <= time)
            {
                Summon(NextBallsNum.Dequeue(), gameObject.transform.position);
                NextSpawn = time + SpawnCool;
                RemoveSample();
            }
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (gameObject.transform.position.x < 2.55)
            {
                gameObject.transform.position += new Vector3(2f * Time.deltaTime, 0, 0);
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (gameObject.transform.position.x > -2.55)
            {
                gameObject.transform.position += new Vector3(-2f * Time.deltaTime, 0, 0);
            }
        }
    }
    void PrefebPools()
    {
        PrefebPool(LLv1, Lv1, Lv1n);
        PrefebPool(LLv2, Lv2, Lv2n);
        PrefebPool(LLv3, Lv3, Lv3n);
        PrefebPool(LLv4, Lv4, Lv4n);
        PrefebPool(LLv5, Lv5, Lv5n);
        PrefebPool(LLv6, Lv6, Lv6n);
        PrefebPool(LLv7, Lv7, Lv7n);
        PrefebPool(LLv8, Lv8, Lv8n);
        PrefebPool(LLv9, Lv9, Lv9n);
        PrefebPool(LLv10, Lv10, Lv10n);
        PrefebPool(LLv11, Lv11, Lv11n);
        PrefebPool(LLv1s, Lv1s, 3);
        PrefebPool(LLv2s, Lv2s, 3);
        PrefebPool(LLv3s, Lv3s, 3);
        PrefebPool(LLv4s, Lv4s, 3);
    }
    void PrefebPool(List<GameObject> list, GameObject ball, int amount)
    {
        GameObject tmp;
        for (int i = 0; i < amount; i++)
        {
            tmp = Instantiate(ball);
            list.Add(tmp);
            tmp.SetActive(false);
        }
    }
    public GameObject GetPooledObject(string Lv)
    {
        switch (Lv)
        {
            case "1":
                {
                    for (int i = 0; i < Lv1n; i++)
                    {
                        if (!LLv1[i].activeInHierarchy)
                        {
                            return LLv1[i];
                        }
                    }
                    return null;
                }
            case "2":
                {
                    for (int i = 0; i < Lv2n; i++)
                    {
                        if (!LLv2[i].activeInHierarchy)
                        {
                            return LLv2[i];
                        }
                    }
                    return null;
                }
            case "3":
                {
                    for (int i = 0; i < Lv3n; i++)
                    {
                        if (!LLv3[i].activeInHierarchy)
                        {
                            return LLv3[i];
                        }
                    }
                    return null;
                }
            case "4":
                {
                    for (int i = 0; i < Lv4n; i++)
                    {
                        if (!LLv4[i].activeInHierarchy)
                        {
                            return LLv4[i];
                        }
                    }
                    return null;
                }
            case "5":
                {
                    for (int i = 0; i < Lv5n; i++)
                    {
                        if (!LLv5[i].activeInHierarchy)
                        {
                            return LLv5[i];
                        }
                    }
                    return null;
                }
            case "6":
                {
                    for (int i = 0; i < Lv6n; i++)
                    {
                        if (!LLv6[i].activeInHierarchy)
                        {
                            return LLv6[i];
                        }
                    }
                    return null;
                }
            case "7":
                {
                    for (int i = 0; i < Lv7n; i++)
                    {
                        if (!LLv7[i].activeInHierarchy)
                        {
                            return LLv7[i];
                        }
                    }
                    return null;
                }
            case "8":
                {
                    for (int i = 0; i < Lv8n; i++)
                    {
                        if (!LLv8[i].activeInHierarchy)
                        {
                            return LLv8[i];
                        }
                    }
                    return null;
                }
            case "9":
                {
                    for (int i = 0; i < Lv9n; i++)
                    {
                        if (!LLv9[i].activeInHierarchy)
                        {
                            return LLv9[i];
                        }
                    }
                    return null;
                }
            case "10":
                {
                    for (int i = 0; i < Lv10n; i++)
                    {
                        if (!LLv10[i].activeInHierarchy)
                        {
                            return LLv10[i];
                        }
                    }
                    return null;
                }
            case "11":
                {
                    for (int i = 0; i < Lv11n; i++)
                    {
                        if (!LLv11[i].activeInHierarchy)
                        {
                            return LLv11[i];
                        }
                    }
                    return null;
                }
            case "1s":
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (!LLv1s[i].activeInHierarchy)
                        {
                            return LLv1s[i];
                        }
                    }
                    return null;
                }
            case "2s":
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (!LLv2s[i].activeInHierarchy)
                        {
                            return LLv2s[i];
                        }
                    }
                    return null;
                }
            case "3s":
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (!LLv3s[i].activeInHierarchy)
                        {
                            return LLv3s[i];
                        }
                    }
                    return null;
                }
            case "4s":
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (!LLv4s[i].activeInHierarchy)
                        {
                            return LLv4s[i];
                        }
                    }
                    return null;
                }
            default: return null;
        }
    }
}
