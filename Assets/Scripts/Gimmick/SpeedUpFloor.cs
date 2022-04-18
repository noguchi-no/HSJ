using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SpeedUpFloor : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject rightArrow;
    public GameObject leftArrow;
    public GameObject player;
    float moveLength;
    public float duration = 1f;
    public Ease easeType;

    public AudioClip speedUpSound;
    AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        Bounds bounds = spriteRenderer.bounds;
        Vector3 vector3 = bounds.size;
        
        float x = vector3.x;
        moveLength = x/6f;
        Debug.Log(moveLength);
    }
    // Start is called before the first frame update
    void Start()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(rightArrow.transform.DOLocalMoveX(moveLength, duration).SetEase(easeType));
        sequence.Join(rightArrow.GetComponent<SpriteRenderer>().DOFade(0, duration).SetEase(Ease.InQuart));
        sequence.SetLoops(-1);

        var sequence2 = DOTween.Sequence();
        sequence2.Append(leftArrow.transform.DOLocalMoveX(-moveLength, duration).SetEase(easeType));
        sequence2.Join(leftArrow.GetComponent<SpriteRenderer>().DOFade(0, duration).SetEase(Ease.InQuart));
        sequence2.SetLoops(-1);
    }

    private void OnCollisionEnter2D(Collision2D other) {

        if(other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Ball"))
        {
            audioSource.PlayOneShot(speedUpSound);
            rb = player.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector3(3.0f*rb.velocity.x, rb.velocity.y, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
