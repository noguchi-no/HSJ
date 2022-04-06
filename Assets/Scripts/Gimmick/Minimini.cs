using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Minimini : MonoBehaviour
{
    public GameObject leftArrow;
    public GameObject rightArrow;
    public float duration = 1f;
    public float smallSize = 1.5f;
    public Ease easeType;
    //public float moveLength;
    public Vector3 vec = new Vector3();
    public AudioClip miniSound;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        var sequence = DOTween.Sequence();
        sequence.Append(rightArrow.transform.DOLocalMove(vec * 1.5f , duration).SetEase(easeType));
        sequence.Join(rightArrow.transform.DOScale(new Vector3(smallSize, smallSize, 1), duration).SetEase(easeType));
        sequence.Append(rightArrow.transform.DOLocalMove(vec, duration).SetEase(easeType));
        sequence.Join(rightArrow.transform.DOScale(new Vector2(smallSize / 3, smallSize / 3) * smallSize, duration).SetEase(easeType));
        sequence.SetLoops(-1);

        var sequence2 = DOTween.Sequence();
        sequence2.Append(leftArrow.transform.DOLocalMove(-vec * 1.5f, duration).SetEase(easeType));
        sequence2.Join(leftArrow.transform.DOScale(new Vector3(smallSize, smallSize, 1), duration).SetEase(easeType));
        sequence2.Append(leftArrow.transform.DOLocalMove(-vec, duration).SetEase(easeType));
        sequence2.Join(leftArrow.transform.DOScale(new Vector2(smallSize / 3, smallSize / 3) * smallSize, duration).SetEase(easeType));
        sequence2.SetLoops(-1);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player")
        {
            audioSource.PlayOneShot(miniSound);
            other.gameObject.transform.localScale = new Vector3(0.1f, 0.1f,1.0f);
            
            //DOVirtual.DelayedCall (0.2f, ()=> Destroy(this.gameObject));
        }  
    }

}
