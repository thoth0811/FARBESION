using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallsShowLevel : MonoBehaviour
{
    public int level;
    int dst = 2;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.localPosition = new Vector3(dst * Mathf.Sin((Mathf.PI * 2) * level / 12), dst * Mathf.Cos((Mathf.PI * 2) * level / 12),0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
