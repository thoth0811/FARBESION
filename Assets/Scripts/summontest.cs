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
    int NextFruit = 0;
    bool isSampleSpawn = false;
    // Start is called before the first frame update
    void RemoveSample()
    {
        GameObject[] Fruits = GameObject.FindGameObjectsWithTag("FruitsSample");
        foreach (GameObject fruit in Fruits)
        {
            Destroy(fruit, 0f);
        }
        isSampleSpawn = false;
    }

    void SpawnSample()
    {
        NextFruit = Random.Range(1, 5);
        switch (NextFruit)
        {
            case 1: Instantiate(Lv1, gameObject.transform.position, Quaternion.identity); break;
            case 2: Instantiate(Lv2, gameObject.transform.position, Quaternion.identity); break;
            case 3: Instantiate(Lv3, gameObject.transform.position, Quaternion.identity); break;
            case 4: Instantiate(Lv4, gameObject.transform.position, Quaternion.identity); break;
            default: break;
        }
        isSampleSpawn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isSampleSpawn)
        {
            if (NextSpawn <= Time.time)
            {
                SpawnSample();
            }
        }
        if (Input.GetKeyDown(KeyCode.Space)){
            if (NextSpawn <= Time.time) {
                SpawnPoint.GetComponent<SummonFruits>().Summon(NextFruit, gameObject.transform.position);
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
        //전체 초기화 테스트용 코드
        //if (Input.GetKey(KeyCode.C))
        //{
        //    SpawnPoint.GetComponent<SummonFruits>().ClearFruits();
        //}
    }
}
