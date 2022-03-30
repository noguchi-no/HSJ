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
    void Start()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(windIcon.transform.DOLocalMove(moveVec, duration));
        sequence.Join(windIcon.GetComponent<SpriteRenderer>().DOFade(0, duration).SetEase(Ease.InQuart));
        sequence.SetLoops(-1);
    }
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Player" && col.TryGetComponent(out Rigidbody2D rb))
        {
            Debug.Log("���̗͂��󂯂Ă���");
            rb.AddForce(force);
        }
    }
}
