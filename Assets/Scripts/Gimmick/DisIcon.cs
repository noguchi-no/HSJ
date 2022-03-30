using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class DisIcon : MonoBehaviour
{
    public List<GameObject> list = new List<GameObject>();
    public float duration;
    public float length;
    public int vibrato;
    void Start() 
    {
        list[0].transform.DOPunchPosition(new Vector2(-length*2f, -length), duration , vibrato).SetLoops(-1);
        list[1].transform.DOPunchPosition(new Vector2(-length * 2f, -length), duration, vibrato).SetLoops(-1);
    }

    void OnCollisionEnter2D(Collision2D other) {

        if(other.gameObject.tag == "Player")
        {
            for(int i = 0; i < list.Count; i++)
            {
                Destroy(list[i]);
            }
        }

        
    }
}
