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
    // Start is called before the first frame update
    bool isMerging = false;
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
        switch (Level)
        {
            case 1: SpawnPoint.GetComponent<SummonFruits>().Score += 1; break;
            case 2: SpawnPoint.GetComponent<SummonFruits>().Score += 3; break;
            case 3: SpawnPoint.GetComponent<SummonFruits>().Score += 6; break;
            case 4: SpawnPoint.GetComponent<SummonFruits>().Score += 10; break;
            case 5: SpawnPoint.GetComponent<SummonFruits>().Score += 15; break;
            case 6: SpawnPoint.GetComponent<SummonFruits>().Score += 21; break;
            case 7: SpawnPoint.GetComponent<SummonFruits>().Score += 28; break;
            case 8: SpawnPoint.GetComponent<SummonFruits>().Score += 36; break;
            case 9: SpawnPoint.GetComponent<SummonFruits>().Score += 45; break;
            case 10: SpawnPoint.GetComponent<SummonFruits>().Score += 55; break;
            case 11: SpawnPoint.GetComponent<SummonFruits>().Score += 66; break;
            default: break;
        }
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
        if (col.gameObject.CompareTag("Fruits") && col.gameObject.GetComponent<Fruits>().Level == this.Level && col.gameObject.GetComponent<Fruits>().isMerging == isMerging)
        {
            isMerging = true;
            Destroy(gameObject, 0f);
            if (col.gameObject.GetComponent<Fruits>().SummonTime  > SummonTime)
            {
                ContactPoint2D contact = col.contacts[0];
                SpawnPoint.GetComponent<SummonFruits>().Summon(Level+1,new Vector3(contact.point.x, contact.point.y, 0));
                AddScore();
                ShowParticle(contact);
            }
            return;
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
