using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    int cnt = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D coll)
    {

        if (cnt == 1) Destroy(this.gameObject);
        cnt++;
    }

    void OnCollisionStay2D(Collision2D coll)
    {

        Destroy(this.gameObject);
    }
}
