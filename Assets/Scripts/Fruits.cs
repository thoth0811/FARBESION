using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruits : MonoBehaviour
{
    public int Level;
    float SummonTime = 0;
    GameObject SpawnPoint;
    float TouchDeadLineTime = 0;
    float DeadLineTime = 3f;
    public ParticleSystem MergeParticle;
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
        
    }

    void AddScore()
    {
        SpawnPoint.GetComponent<SummonFruits>().Score += Level*(Level+1)/2;
    }
    void ShowParticle(ContactPoint2D contact)
    {
        switch (Level)
        {
            case 1: Instantiate(MergeParticle, new Vector3(contact.point.x, contact.point.y, 0), Quaternion.identity); break;
            case 2: Instantiate(MergeParticle, new Vector3(contact.point.x, contact.point.y, 0), Quaternion.identity); break;
            case 3: Instantiate(MergeParticle, new Vector3(contact.point.x, contact.point.y, 0), Quaternion.identity); break;
            case 4: Instantiate(MergeParticle, new Vector3(contact.point.x, contact.point.y, 0), Quaternion.identity); break;
            case 5: Instantiate(MergeParticle, new Vector3(contact.point.x, contact.point.y, 0), Quaternion.identity); break;
            case 6: Instantiate(MergeParticle, new Vector3(contact.point.x, contact.point.y, 0), Quaternion.identity); break;
            case 7: Instantiate(MergeParticle, new Vector3(contact.point.x, contact.point.y, 0), Quaternion.identity); break;
            case 8: Instantiate(MergeParticle, new Vector3(contact.point.x, contact.point.y, 0), Quaternion.identity); break;
            case 9: Instantiate(MergeParticle, new Vector3(contact.point.x, contact.point.y, 0), Quaternion.identity); break;
            case 10: Instantiate(MergeParticle, new Vector3(contact.point.x, contact.point.y, 0), Quaternion.identity); break;
            case 11: Instantiate(MergeParticle, new Vector3(contact.point.x, contact.point.y, 0), Quaternion.identity); break;
            default: break;
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Fruits") && col.gameObject.GetComponent<Fruits>().Level == this.Level)
        {
            if(isMerge == false && col.gameObject.GetComponent<Fruits>().isMerge == false)
            {
                isMerge = true;
                col.gameObject.GetComponent<Fruits>().isMerge = true;
                if (col.gameObject.GetComponent<Fruits>().SummonTime < SummonTime)
                {
                    ContactPoint2D contact = col.contacts[0];
                    SpawnPoint.GetComponent<SummonFruits>().Summon(Level + 1, new Vector3(contact.point.x, contact.point.y, 0));
                    AddScore();
                    ShowParticle(contact);
                }
                Destroy(gameObject, 0f);
                Destroy(col.gameObject,0f);
                return;
            }
        }
        if (col.gameObject.CompareTag("FruitsRemover"))
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
                SpawnPoint.GetComponent<SummonFruits>().ClearFruits();
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
}
