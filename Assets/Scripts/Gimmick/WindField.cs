using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WindField : MonoBehaviour
{
    [SerializeField]
    private Vector2 force;

    //方向とアイコン画像の向きはステージごとに必要あり
    public GameObject windIcon;
    public Vector3 moveVec;
    public float duration;

    public AudioClip windSound;
    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        var sequence = DOTween.Sequence();
        sequence.Append(windIcon.transform.DOLocalMove(moveVec, duration));
        sequence.Join(windIcon.GetComponent<SpriteRenderer>().DOFade(0, duration).SetEase(Ease.InQuart));
        sequence.SetLoops(-1);
    }
    private void OnTriggerStay2D(Collider2D col)
    {
        if ((col.CompareTag("Player") || col.CompareTag("Ball"))&& col.TryGetComponent(out Rigidbody2D rb))
        {
            rb.AddForce(force);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            audioSource.PlayOneShot(windSound);
        }
    }
}
