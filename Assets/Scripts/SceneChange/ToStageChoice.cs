using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ToStageChoice : MonoBehaviour
{
    public Image leftBackGround;
    public Image rightBackGround;
    public Text titleText;
    public float moveLength;
    public float duration;
    public Ease easeType;
    public Vector2 jumpDestination = new Vector2();
    public float jumpDuration;
    public float jumpPower;

    public RectTransform panelRectTransform;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnClick (){
        
        var sequence = DOTween.Sequence();
        sequence.Append(leftBackGround.rectTransform.DOLocalMoveX(-moveLength, duration));
        sequence.Join(rightBackGround.rectTransform.DOLocalMoveX(moveLength, duration));
        sequence.Join(titleText.DOFade(0f,duration));
        sequence.Join(this.gameObject.transform.DOLocalJump(jumpDestination, jumpPower, 3, jumpDuration).SetEase(Ease.Linear));
        sequence.Append(panelRectTransform.DOLocalMoveX(0f, 1f).SetEase(easeType));
        
        // .OnComplete(() =>
        // {

        // });
         //sequence.AppendInterval(1f);
         //titleText.rectTransform.DOMoveY(1200f, duration);

         //leftBackGround.rectTransform.DOLocalMoveX(-1 * moveLength, duration).SetEase(easeType);
         //rightBackGround.rectTransform.DOLocalMoveX(moveLength, duration).SetEase(easeType);
         //FadeManager.Instance.LoadScene ("StageChoice", 0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
