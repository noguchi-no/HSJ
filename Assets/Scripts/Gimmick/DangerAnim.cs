using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DangerAnim : MonoBehaviour
{
    public float duration;
    // Start is called before the first frame update
    void Start()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(gameObject.GetComponent<SpriteRenderer>().DOFade(0, duration));
        sequence.SetLoops(-1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
