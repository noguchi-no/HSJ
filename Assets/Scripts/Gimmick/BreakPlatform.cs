using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BreakPlatform : MonoBehaviour
{
    public static bool broken;
    public GameObject effect;
    // public AudioClip breakSound;
    // AudioSource audioSource;

    void Start()
    {
        broken = false;
        //audioSource = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter2D(Collision2D other) {
        
        if(other.gameObject.tag == "Player")
        {
            broken = true;
            //audioSource.PlayOneShot(breakSound);
            DOVirtual.DelayedCall (0.1f, ()=> delay()); 
            
            
        }
        
    }
    void delay()
    {
        effect.gameObject.transform.parent = null;
        Destroy(this.gameObject);
    }

}
