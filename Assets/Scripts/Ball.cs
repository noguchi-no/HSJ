using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public PhysicsMaterial2D physicsMaterial2D;

    int cnt = 0;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D coll)
    { 
        
        if(cnt == 1) {
            Destroy(this.gameObject);
            //rb.sharedMaterial = physicsMaterial2D;
        }

        cnt++;
    }

    void OnCollisionStay2D(Collision2D coll)
    {

        Destroy(this.gameObject);
    }
}
