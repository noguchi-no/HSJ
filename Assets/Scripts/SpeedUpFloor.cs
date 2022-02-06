using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpFloor : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        
        rb = player.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector3(3.0f*rb.velocity.x, rb.velocity.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
