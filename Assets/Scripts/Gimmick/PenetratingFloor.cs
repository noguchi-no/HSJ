using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PenetratingFloor : MonoBehaviour
{
    [SerializeField]
    private Collider2D CheckPos;

    public GameObject arrow;
    public float moveLength = 1f; 
    public float duration;
    public Ease easeType;

    void Start()
    {   
        var sequence = DOTween.Sequence();
        sequence.Append(arrow.transform.DOLocalMoveY(moveLength, duration).SetEase(easeType));
        sequence.Append(arrow.GetComponent<SpriteRenderer>().DOFade(0, 1f));
        sequence.SetLoops(-1);

        CheckPos.isTrigger = true;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("�R���C�_�[�ɓ�����");
        if(col.tag == "Player" && checkDistance(col.gameObject))
        {
            CheckPos.isTrigger = true;
        }
        else if (col.tag == "Player" && !checkDistance(col.gameObject))
        {
            CheckPos.isTrigger = false;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player" && !checkDistance(col.gameObject))
        {
            CheckPos.isTrigger = false;
        }
    }


    private bool checkDistance(GameObject Player)
    {
        return Player.gameObject.transform.position.y <= this.gameObject.transform.position.y;
    }
}
