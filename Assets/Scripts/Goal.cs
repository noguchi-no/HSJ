using System.Collections;
using System.Collections.Generic;
using Systems.Audio;
using UnityEngine;
using AudioType = Systems.Audio.AudioType;

public class Goal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name);

        if (other.gameObject.name == "Player")
        {
            Debug.Log("GOAL!!!");
            Destroy(this.gameObject);
            PlayBoundSe();
        }
    }

    private void PlayBoundSe()
    {
        var Se = FindObjectOfType<SystemAudioManager>();
        if (Se != null) Se.ShotSe(AudioType.Goal);
        else Debug.LogError("Sesystem‚ªŽÀ‘•‚³‚ê‚Ä‚¢‚Ü‚¹‚ñ");
    }
}
