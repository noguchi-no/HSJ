using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityReverse : MonoBehaviour
{
    public GameObject player;
    Rigidbody2D rb;
    Vector2 changeGravity;
    bool changedGravity;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D other)
    {

        rb = player.GetComponent<Rigidbody2D>();
        changeGravity = new Vector2(0, 9.81f * 2f);
        changedGravity = true;
        
    }

    void FixedUpdate()
    {
        //Physics.gravity = new Vector3(0, 20, 0);
        if(changedGravity)rb.AddForce(changeGravity);
    }

}
