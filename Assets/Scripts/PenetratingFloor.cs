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
        Debug.Log("コライダーに入った");
        if(col.tag == "Player" && checkDistance(col.gameObject))
        {
            CheckPos.isTrigger = true;
        }
        else
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
