using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    #region
    private enum Stage
    {
        stage1,
        stage2,
        stage3,
        stage4,
        stage5,
        stage6,
        stage7,
        stage8,
        stage9,
        stage10,
        stage11,
        stage12,
        stage13,
        stage14,
        stage15,
        stage16,
        stage17,
        stage18,
        stage19,
        stage20,
        stage21,
        stage22,
        stage23,
        stage24,
        stage25,
    }
    #endregion
    [SerializeField]
    private Stage nowStage;
    private Text TitleText;
    private Text SubTitleText;
    private GameObject Player;
    private Player_Physics PlayerCs;
    private GameObject StageClearText;
    [SerializeField]
    private SceneObject nextScene;
    [SerializeField]
    private int nowStageNum;
    [SerializeField]
    private GameObject WarpGate;

    private void Awake()
    {
        StageClearText = GameObject.Find("StageClear");
        StageClearText.SetActive(false);
    }
    #region
    static bool stage1 = false;
    static bool stage2 = false;
    static bool stage3 = false;
    static bool stage4 = false;
    static bool stage5 = false;
    static bool stage6 = false;
    static bool stage7 = false;
    static bool stage8 = false;
    static bool stage9 = false;
    static bool stage10 = false;
    static bool stage11 = false;
    static bool stage12 = false;
    static bool stage13 = false;
    static bool stage14 = false;
    static bool stage15 = false;
    static bool stage16 = false;
    static bool stage17 = false;
    static bool stage18 = false;
    static bool stage19 = false;
    static bool stage20 = false;
    static bool stage21 = false;
    static bool stage22 = false;
    static bool stage23 = false;
    static bool stage24 = false;
    static bool stage25 = false;
    #endregion
    void Start()
    {
        TitleText = GameObject.Find("TitleText").GetComponent<Text>();
        SubTitleText = GameObject.Find("SubTitleText").GetComponent<Text>();
        PlayerCs = FindObjectOfType<Player_Physics>().GetComponent<Player_Physics>();
        Player = GameObject.Find("Player");
        switch (nowStage)
        {
            case Stage.stage1:
                if (stage1) break;
                startAnime();
                stage1 = true;
                break;
        }
    }
    private void startAnime()
    {
        TitleText.DOFade(1.0f, 1.5f).SetEase(Ease.InOutQuint).SetLoops(2, LoopType.Yoyo);
        SubTitleText.DOFade(1.0f, 1.5f).SetEase(Ease.InOutQuint).SetLoops(2, LoopType.Yoyo);
        if (PlayerCs != null) PlayerCs.titleCallPowerWait();
        if (WarpGate != null) StartCoroutine(PlayerWarpStart());
    }

    public void stageClear()
    {
        StageClearText.SetActive(true);
        StartCoroutine("SceneChange");
    }

    IEnumerator SceneChange()
    {
        PlayerPrefs.SetInt("stageNum", nowStageNum);
        PlayerPrefs.Save();
        yield return new WaitForSeconds(3f);

        FadeManager.Instance.LoadScene(nextScene, 0f);
    }

    IEnumerator PlayerWarpStart()
    {
        var color = Player.GetComponent<SpriteRenderer>();
        color.color = new Color(0, 0, 0, 0);
        yield return new WaitForSeconds(1f);
        WarpGate.transform.position = Player.transform.position;
        WarpGate.transform.DOScale(new Vector3(0.7f, 0.7f, 0.7f), 1.0f);
        WarpGate.transform.DORotate(new Vector3(0f, 0f, -360f), 1.0f, RotateMode.FastBeyond360).SetEase(Ease.Linear);
        yield return new WaitForSeconds(1.0f);
        color.color = new Color(1, 1, 1, 1);
        WarpGate.transform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), 1.0f);
        WarpGate.transform.DORotate(new Vector3(0f, 0f, -360f), 1.0f, RotateMode.FastBeyond360).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.9f);
        WarpGate.SetActive(false);
    }

}
