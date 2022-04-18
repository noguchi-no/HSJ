using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TitleRandomPopUpGimmick : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Gimmicks;
    void Start()
    {
        StartCoroutine(RandomPopUpTimer());
    }

    IEnumerator RandomPopUp()
    {
        while (true)
        {

            yield return new WaitForSeconds(1f);
            int RandomInt = Random.Range(0, Gimmicks.Length);
            var RandomVecter3 = new Vector3(Random.Range(-8.5f, 8.5f), Random.Range(-5f, 5f), 0);
            var GimmickPop = Instantiate(Gimmicks[RandomInt], RandomVecter3, Quaternion.identity);
            var Renderer = GimmickPop.GetComponent<SpriteRenderer>();
            Renderer.color = new Color(Renderer.color.r, Renderer.color.g, Renderer.color.b, 0);
            Renderer.DOFade(1f, 4f).SetEase(Ease.InOutQuint).SetLoops(2, LoopType.Yoyo);
            yield return new WaitForSeconds(8f);
            Destroy(GimmickPop);
        }
    }
    IEnumerator RandomPopUpTimer()
    {
        StartCoroutine(RandomPopUp());
        yield return new WaitForSeconds(3f);
        StartCoroutine(RandomPopUp());
        yield return new WaitForSeconds(3f);
        StartCoroutine(RandomPopUp());
    }
}
