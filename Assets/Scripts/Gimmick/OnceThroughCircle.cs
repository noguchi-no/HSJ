using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OnceThroughCircle : MonoBehaviour
{
    private Collider2D CircleCol;
    public AudioClip Sound;
    AudioSource audioSource;
    void Start()
    {
        CircleCol = GetComponent<CircleCollider2D>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player" && col.TryGetComponent(out Rigidbody2D rb))
        {
            GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, 200f);
            audioSource.PlayOneShot(Sound);
            CircleCol.isTrigger = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if ((col.gameObject.CompareTag("Player") || col.gameObject.CompareTag("Ball")) && col.gameObject.TryGetComponent(out Rigidbody2D rb))
        {
            rb.velocity = new Vector3(2.0f * rb.velocity.x, 2.0f * rb.velocity.y, 0);
        }
    }
}
