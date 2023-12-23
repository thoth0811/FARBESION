using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruits : MonoBehaviour
{
    public int Level;
    public float SummonTime;
    public GameObject SpawnPoint = GameObject.FindWithTag("SpawnPoint");
    // Start is called before the first frame update
    void Start()
    {
        SummonTime = Time.time;
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
                    SpawnPoint.GetComponent<SummonFruits>().Summon((this.Level + 1), col.transform);
                }
                Destroy(gameObject, 0f);
                return;
            }
        }
    }
}
