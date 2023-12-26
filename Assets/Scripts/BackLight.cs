using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackLight : MonoBehaviour
{
    public int x, y, X_WaveSize, Y_WaveSize;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(x + X_WaveSize * Mathf.Sin(Time.time), y + Y_WaveSize * Mathf.Sin(Time.time), 0);
    }
}
