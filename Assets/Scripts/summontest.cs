using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class summontest : MonoBehaviour
{
    public GameObject Lv1;
    public GameObject Lv2;
    public GameObject Lv3;
    public GameObject Lv4;
    public GameObject SpawnPoint;
    public float SpawnCool = 0.5f;
    float NextSpawn;
    Queue<int> NextBalls = new Queue<int>(3);
    int[] NextBall = new int[3];
    bool isSampleSpawn = false;
    GameObject Ball;
    GameObject[] Balls = new GameObject[3];
    // Start is called before the first frame update
    void Start()
    {
        NextBalls.Enqueue(Random.Range(1, 5));
        NextBalls.Enqueue(Random.Range(1, 5));
        NextBalls.Enqueue(Random.Range(1, 5));
    }

    void RemoveSample()
    {
        NextBalls.Enqueue(Random.Range(1, 5));
        foreach (GameObject ball in Balls)
        {
            Destroy(ball, 0f);
        }

        isSampleSpawn = false;
    }

    void SpawnSample()
    {
        isSampleSpawn = true;
        NextBall = NextBalls.ToArray();
        switch (NextBall[0])
        {
            case 1: Ball = Instantiate(Lv1, gameObject.transform.position, Quaternion.identity); break;
            case 2: Ball = Instantiate(Lv2, gameObject.transform.position, Quaternion.identity); break;
            case 3: Ball = Instantiate(Lv3, gameObject.transform.position, Quaternion.identity); break;
            case 4: Ball = Instantiate(Lv4, gameObject.transform.position, Quaternion.identity); break;
            default: break;
        }
        Balls[0] = Ball;
        Ball.gameObject.GetComponent<BallsSample>().isNext = true;
        switch (NextBall[1])
        {
            case 1: Balls[1] = Instantiate(Lv1, new Vector3(-5, 4.5f, 0), Quaternion.identity); break;
            case 2: Balls[1] = Instantiate(Lv2, new Vector3(-5, 4.5f, 0), Quaternion.identity); break;
            case 3: Balls[1] = Instantiate(Lv3, new Vector3(-5, 4.5f, 0), Quaternion.identity); break;
            case 4: Balls[1] = Instantiate(Lv4, new Vector3(-5, 4.5f, 0), Quaternion.identity); break;
            default: break;          
        }                            
        switch (NextBall[2])         
        {                            
            case 1: Balls[2] = Instantiate(Lv1, new Vector3(-7, 4.5f, 0), Quaternion.identity); break;
            case 2: Balls[2] = Instantiate(Lv2, new Vector3(-7, 4.5f, 0), Quaternion.identity); break;
            case 3: Balls[2] = Instantiate(Lv3, new Vector3(-7, 4.5f, 0), Quaternion.identity); break;
            case 4: Balls[2] = Instantiate(Lv4, new Vector3(-7, 4.5f, 0), Quaternion.identity); break;
            default: break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isSampleSpawn)
        {
            SpawnSample();

        }
        if (Input.GetKeyDown(KeyCode.Space)){
            if (NextSpawn <= Time.time) {
                SpawnPoint.GetComponent<SummonBalls>().Summon(NextBalls.Dequeue(), gameObject.transform.position);
                NextSpawn = Time.time + SpawnCool;
                RemoveSample();
            }
        }
        if (Input.GetKey(KeyCode.RightArrow)) { 
            if(gameObject.transform.position.x < 2.85) {
                gameObject.transform.position += new Vector3(0.01f, 0, 0);
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (gameObject.transform.position.x > -2.85)
            {
                gameObject.transform.position += new Vector3(-0.01f, 0, 0);
            }
        }
    }
}
