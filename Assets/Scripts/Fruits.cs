using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruits : MonoBehaviour
{
    public int Level;
    public GameObject Prefeb;

    // Start is called before the first frame update
    void Start()
    {
        
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
                Vector3 fruit1 = gameObject.transform.position;
                Vector3 fruit2 = col.gameObject.transform.position;
                Instantiate(Prefeb, Vector3.Lerp(fruit1, fruit2, 0.5f));
                Destroy(col.gameObject, 0f);
                Destroy(this, 0f);
                return;
            }
        }
    }
}
