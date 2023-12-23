using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruits : MonoBehaviour
{
    public int Level;
    public float SummonTime;
    public GameObject SpawnPoint;
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
                if (col.gameObject.GetComponent<Fruits>().SummonTime  > SummonTime)
                {
                    ContactPoint2D contact = col.contacts[0];
                    SpawnPoint.GetComponent<SummonFruits>().Summon((this.Level+1),new Vector3(contact.point.x, contact.point.y, 0));
                }
                Destroy(gameObject, 0f);
                return;
            }
        }
    }
}
