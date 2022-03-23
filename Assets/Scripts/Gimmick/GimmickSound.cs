using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickSound : MonoBehaviour
{
    public AudioClip sound;
    //SystemAudioManager Se;
    AudioSource audiosource1;

    void Start()
    {
        //Se = FindObjectOfType<SystemAudioManager>();
        audiosource1 = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision) 
    {
        //AudioSource.PlayClipAtPoint(sound, transform.position);
        audiosource1.PlayOneShot(sound);
    }
}
