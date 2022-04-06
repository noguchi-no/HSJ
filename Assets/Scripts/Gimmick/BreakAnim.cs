using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class BreakAnim : MonoBehaviour
{
    public GameObject rightBlock;
    public GameObject leftBlock;
    public Vector3 rightVec;
    public Vector3 leftVec;
    public float duration;
    public AudioClip breakSound;
    AudioSource audioSource;
    bool isSe;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(BreakPlatform.broken)
        {
            if(!isSe) {                
                audioSource.PlayOneShot(breakSound);
                isSe = true;
            }
            BreakPlatform.broken = false;
            rightBlock.transform.DOLocalRotate(new Vector3(0.0f, 0.0f, -30f), duration);
            rightBlock.transform.DOLocalMove(rightVec, duration);
            leftBlock.transform.DOLocalRotate(new Vector3(0.0f, 0.0f, 30f), duration);
            leftBlock.transform.DOLocalMove(leftVec, duration)
            .OnComplete(() =>
            {
                gameObject.SetActive(false);
            });
        }
    }
}
