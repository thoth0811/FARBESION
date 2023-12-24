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

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Fruits"))
        {
            if(col.gameObject.GetComponent<Fruits>().Level == this.Level)
            {
                Destroy(gameObject, 0f);
                if (col.gameObject.GetComponent<Fruits>().SummonTime  > SummonTime)
                {
                    ContactPoint2D contact = col.contacts[0];
                    SpawnPoint.GetComponent<SummonFruits>().Summon((this.Level+1),new Vector3(contact.point.x, contact.point.y, 0));
                }

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
