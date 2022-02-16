using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Game8Manager : MonoBehaviour
{
    public GameObject eyes;
    public GameObject OverFace;
    public GameObject UnderToge;
    [SerializeField] float moveValue = 0.5f;
    [SerializeField] float duration = 1f;
    [SerializeField] Ease ease = Ease.InOutSine;
    // Start is called before the first frame update
    void Start()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(eyes.transform.DOMoveX(-moveValue, duration).SetRelative());
        sequence.Append(eyes.transform.DOMoveX(moveValue, duration).SetRelative());

        DOVirtual.DelayedCall(duration*4, () => MoveTweening());
    }
    private void MoveTweening()
    {
        var tweenParams = new TweenParams().SetEase(ease).SetRelative();

        var sequence = DOTween.Sequence();
        sequence.Append(OverFace.transform.DOMoveY(-moveValue, duration).SetAs(tweenParams));
        sequence.Join(UnderToge.transform.DOMoveY(moveValue, duration).SetAs(tweenParams));
        sequence.Append(OverFace.transform.DOMoveY(moveValue, duration).SetAs(tweenParams));
        sequence.Join(UnderToge.transform.DOMoveY(-moveValue, duration).SetAs(tweenParams));
        sequence.SetLoops(-1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
