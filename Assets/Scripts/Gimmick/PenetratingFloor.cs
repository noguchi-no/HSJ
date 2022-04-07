using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenetratingFloor : MonoBehaviour
{
    [SerializeField]
    private Collider2D CheckPos;

    void Start()
    {
        CheckPos.isTrigger = true;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("�R���C�_�[�ɓ�����");
        if((col.tag == "Ball" || col.tag == "Player") && checkDistance(col.gameObject))
        {
            CheckPos.isTrigger = true;
        }
        else if ((col.tag == "Ball" || col.tag == "Player") && !checkDistance(col.gameObject))
        {
            CheckPos.isTrigger = false;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if ((col.tag == "Ball" || col.tag == "Player") && !checkDistance(col.gameObject))
        {
            CheckPos.isTrigger = false;
        }
    }


    private bool checkDistance(GameObject Player)
    {
        return Player.gameObject.transform.position.y <= this.gameObject.transform.position.y;
    }
}
