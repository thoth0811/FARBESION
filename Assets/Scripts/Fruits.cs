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
                ContactPoint2D contact = col.contacts[0];
                Transform pos = contact.point;
                Instantiate(Prefeb, (pos.x, pos.y, 0));
                Destroy(col.gameObject, 0f);
                Destroy(this, 0f);
                return;
            }
        }
    }
}
