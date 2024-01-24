using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balls : MonoBehaviour
{
    public int Level;
    public float SummonTime = 0;
    public ParticleSystem MergeParticle;
    public AudioSource BounceSound;
    public bool isMerge = false, CheckWarning = false;
    int TouchDeadLineCount = 0;
    float TouchDeadLineTime = 0, DeadLineTime = 1f, BounceSoundVolume = 0.1f, BounceSoundSpeed = 2f, PopPower = 0;
    bool GameOver = false;
    GameObject SpawnPoint, BackLight;
    // Start is called before the first frame update
    void Start()
    {
        SpawnPoint = GameObject.FindWithTag("SpawnPoint");
        BackLight = GameObject.FindWithTag("BackLight");
        BounceSound.volume = BounceSoundVolume;
        PopPower = BackLight.GetComponent<BackLight>().PopPower;
    }
    void OnEnable()
    {
        TouchDeadLineCount = 0;
        SummonTime = Time.time;
        isMerge = false;
        CheckWarning = false;
        BallPop();
    }
    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 1.0f && BackLight.GetComponent<BackLight>().IsPause && !GameOver)
        {
            Time.timeScale = 0f;
        }
        if (BackLight.GetComponent<BackLight>().GameOver && !GameOver)
        {
            GameOver = true;
            Time.timeScale = 0f;
        }
        if (Time.timeScale == 0f && !BackLight.GetComponent<BackLight>().IsPause && !GameOver)
        {
            Time.timeScale = 1.0f;
        }
        CheckBallOut();
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Balls") && col.gameObject.GetComponent<Balls>().Level == this.Level)
        {
            if (isMerge == false && col.gameObject.GetComponent<Balls>().isMerge == false)
            {
                if (col.gameObject.GetComponent<Balls>().SummonTime < this.SummonTime)
                {
                    isMerge = true;
                    col.gameObject.GetComponent<Balls>().isMerge = true;
                    ContactPoint2D contact = col.contacts[0];
                    if (!BackLight.GetComponent<BackLight>().RandomMerge)
                    {
                        SpawnPoint.GetComponent<SummonBalls>().Summon(Level + 1, new Vector3(contact.point.x, contact.point.y, 0));
                    }
                    else
                    {
                        SpawnPoint.GetComponent<SummonBalls>().Summon(Random.Range(1, 12), new Vector3(contact.point.x, contact.point.y, 0));
                    }

                    AddScore();
                    ShowParticle(contact);
                    col.gameObject.SetActive(false);
                    gameObject.SetActive(false);
                }
                return;
            }
        }
        if ((col.gameObject.CompareTag("Balls") && col.gameObject.GetComponent<Balls>().Level != this.Level) || col.gameObject.CompareTag("BallsBasket"))
        {
            if (col.relativeVelocity.magnitude > BounceSoundSpeed) {
                Invoke("PlayBounce", 0f);
                if (!CheckWarning)
                {
                    CheckWarning = true;
                }
            }
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("DeadLine"))
        {
            if(TouchDeadLineCount == 0)
            {
                TouchDeadLineCount++;
                TouchDeadLineTime = Time.time + DeadLineTime;
            }
            else
            {
                if (Time.time < TouchDeadLineTime)
                {
                    TouchDeadLineTime = Time.time + DeadLineTime;
                }
                else
                {
                    SetGameOver();
                }
            }
        }
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("DeadLine"))
        {
            if(Time.time >= TouchDeadLineTime)
            {
                SetGameOver();
            }
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("DeadLine"))
        {
            TouchDeadLineTime = 0;
        }
    }
    void AddScore()
    {
        SpawnPoint.GetComponent<SummonBalls>().Score += Level * (Level + 1) / 2;
    }
    void ShowParticle(ContactPoint2D contact)
    {
        Instantiate(MergeParticle, new Vector3(contact.point.x, contact.point.y, 0), Quaternion.identity);
    }
    void CheckBallOut()
    {
        if(this.transform.position.x > 2.9f - 0.15f * Level)
        {
            this.transform.position = new Vector3(2.9f - 0.15f * Level, this.transform.position.y, 0);
        }
        if (this.transform.position.x < -2.9f + 0.15f * Level)
        {
            this.transform.position = new Vector3(-2.9f + 0.15f * Level, this.transform.position.y, 0);
        }
        if (this.transform.position.y < -4.4f + 0.15f * Level)
        {
            this.transform.position = new Vector3(this.transform.position.x, -4.4f + 0.15f * Level, 0);
        }
    }
    void SetGameOver()
    {
        BackLight.GetComponent<BackLight>().GameOver = true;
    }
    void BallPop()
    {
        GameObject[] GameBalls = GameObject.FindGameObjectsWithTag("Balls");
        foreach (GameObject ball in GameBalls)
        {
            if (Vector2.Distance(ball.transform.position, gameObject.transform.position) < (0.1f + 0.3f * (ball.GetComponent<Balls>().Level + Level)))
            {
                Rigidbody2D ballRb = ball.GetComponent<Rigidbody2D>();
                if (ballRb != null)
                {
                    ballRb.AddForce((ball.transform.position - gameObject.transform.position) * PopPower, ForceMode2D.Impulse);
                }
            }
        }
    }
    void PlayBounce()
    {
        BounceSound.Play();
    }
}