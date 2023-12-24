using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class summontest : MonoBehaviour
{
    public GameObject SpawnPoint;
    public float SpawnCool;
    public float NextSpawn;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            if (NextSpawn <= Time.time) {
                SpawnPoint.GetComponent<SummonFruits>().Summon(Random.Range(1,6), gameObject.transform.position);
                NextSpawn = Time.time + SpawnCool;
            }
        }
        if (Input.GetKey(KeyCode.RightArrow)) { 
            if(gameObject.transform.position.x < 2.35) {
                gameObject.transform.position += new Vector3(0.01f, 0, 0);
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (gameObject.transform.position.x > -2.35)
            {
                gameObject.transform.position += new Vector3(-0.01f, 0, 0);
            }
        }
        if (Input.GetKey(KeyCode.C))
        {
            SpawnPoint.GetComponent<SummonFruits>().ClearFruits();
        }
    }
}
