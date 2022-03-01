using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFriction : MonoBehaviour
{
    private bool isGround;
    private Rigidbody2D rb2;
    private GameObject Player;
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        rb2 = Player.GetComponentInParent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = Player.transform.position;
        Debug.Log(isGround);
        if (isGround)
        {
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isGround = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isGround = false;
    }
}
