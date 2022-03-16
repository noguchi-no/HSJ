using System.Collections;
using System.Collections.Generic;
using Systems.Audio;
using UnityEngine;
using UnityEngine.SceneManagement;
using AudioType = Systems.Audio.AudioType;

public class DeathObstacle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Player")
        {
            PlayBoundSe(AudioType.Bound);
            StartCoroutine("restart", other.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player")
        {
            PlayBoundSe(AudioType.Bound);
            StartCoroutine("restart", other.gameObject);
        }  
    }

    private void PlayBoundSe(AudioType type)
    {
        var Se = FindObjectOfType<SystemAudioManager>();
        if (Se != null) Se.ShotSe(type);
        else Debug.LogError("Sesystem����������Ă��܂���");
    }
    IEnumerator restart(GameObject obj)
    {
        Destroy(obj);
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
