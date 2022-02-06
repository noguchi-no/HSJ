using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrictionIncrease : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        //var material = player.GetComponent<Rigidbody2D>().sharedMaterial;
        //material.friction = 1000f;
        //material.bounciness = 0f;
    }
}
