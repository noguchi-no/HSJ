using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmikGenerator : MonoBehaviour
{
    public GameObject[] gimmiks;
    public float span;
    float t;

    int num = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;

        if(span < t)
        {
            
            if(num >= gimmiks.Length) num = 0;

            t = 0.0f;
            GameObject o = Instantiate(gimmiks[num], transform.position, Quaternion.identity);
            o.SetActive(true);
            num++;
        }

    }
}
