using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SwitchWall : MonoBehaviour
{

    public GameObject wall;
    public GameObject offSwitch;
    public GameObject onSwitch;
    public float duration = 1f;
    public float length = 10f;

    public AudioClip switchSound;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name);

        if (other.gameObject.tag == "Player")
        {
            offSwitch.SetActive(false);
            onSwitch.SetActive(true);
            gameObject.transform.DOScaleY(0, duration);
            //Destroy(wall);
            audioSource.PlayOneShot(switchSound);

            wall.transform.DOLocalMoveY(length,0.5f)
            .OnComplete(() => Destroy(gameObject)); 
            
        }
    }
}
