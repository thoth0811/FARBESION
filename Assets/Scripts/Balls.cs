using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balls : MonoBehaviour
{
    public int Level;
    float SummonTime = 0;
    GameObject SpawnPoint;
    float TouchDeadLineTime = 0;
    float DeadLineTime = 3f;
    public ParticleSystem MergeParticle;
    public AudioSource BounceSound;
    float BounceSoundVolume = 0.1f;
    float BounceSoundSpeed = 1.5f;
    bool isMerge = false;
    // Start is called before the first frame update
    void Start()
    {
        SummonTime = Time.time;
        SpawnPoint = GameObject.FindWithTag("SpawnPoint");
    }

    // Update is called once per frame
    void Update()
    {
        BounceSound.volume = BounceSoundVolume;
        CheckBallOut();
    }
    void AddScore()
    {
        SpawnPoint.GetComponent<SummonBalls>().Score += Level * (Level + 1) / 2;
    }
    void ShowParticle(ContactPoint2D contact)
    {
        Instantiate(MergeParticle, new Vector3(contact.point.x, contact.point.y, 0), Quaternion.identity);
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Balls") && col.gameObject.GetComponent<Balls>().Level == this.Level)
        {
            if (isMerge == false && col.gameObject.GetComponent<Balls>().isMerge == false)
            {
                isMerge = true;
                col.gameObject.GetComponent<Balls>().isMerge = true;
                if (col.gameObject.GetComponent<Balls>().SummonTime < SummonTime)
                {
                    ContactPoint2D contact = col.contacts[0];
                    SpawnPoint.GetComponent<SummonBalls>().Summon(Level + 1, new Vector3(contact.point.x, contact.point.y, 0));
                    AddScore();
                    ShowParticle(contact);
                }
                Destroy(gameObject, 0f);
                Destroy(col.gameObject, 0f);
                return;
            }
        }
        if (col.gameObject.CompareTag("Balls") && col.gameObject.GetComponent<Balls>().Level != this.Level)
        {
            if (col.relativeVelocity.magnitude > BounceSoundSpeed) {
                BounceSound.Play();
            }
        }
    
        if (col.gameObject.CompareTag("BallsBasket"))
        {
            if (col.relativeVelocity.magnitude > BounceSoundSpeed) {
                BounceSound.Play();
            }
        }
            if (col.gameObject.CompareTag("BallsRemover"))
        {
            Destroy(gameObject, 0f);
            return;
        }
        if (col.gameObject.CompareTag("DeadLine"))
        {
                TouchDeadLineTime = Time.time + DeadLineTime;
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("DeadLine"))
        {
            TouchDeadLineTime = Time.time + DeadLineTime;
        }
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("DeadLine"))
        {
            if(Time.time >= TouchDeadLineTime)
            {
                SpawnPoint.GetComponent<SummonBalls>().ClearBalls();
                SpawnPoint.GetComponent<SummonBalls>().Score = 0;
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

    void CheckBallOut()
    {
        if(this.transform.position.x > 3)
        {
            this.transform.position = new Vector3(2.9f - 0.15f * Level, this.transform.position.y, 0);
        }
        if (this.transform.position.x < -3)
        {
            this.transform.position = new Vector3(-2.9f + 0.15f * Level, this.transform.position.y, 0);
        }
        if (this.transform.position.y < -4.5f)
        {
            this.transform.position = new Vector3(this.transform.position.x, -4.4f + 0.15f * Level, 0);
        }
    }
}
