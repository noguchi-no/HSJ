using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindField : MonoBehaviour
{
    [SerializeField]
    private Vector2 force;


    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Player" && col.TryGetComponent(out Rigidbody2D rb))
        {
            rb.AddForce(force);
        }
    }
}
