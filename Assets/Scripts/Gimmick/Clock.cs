using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;   

public class Clock : MonoBehaviour
{
    public GameObject second;
    public GameObject minute;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DateTime dt = DateTime.Now;
        minute.transform.eulerAngles = new Vector3(0,0,(float)dt.Minute/60*-360);
        second.transform.eulerAngles = new Vector3(0,0,(float)dt.Second/60*-360);
    }
}
