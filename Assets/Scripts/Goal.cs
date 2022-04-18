using System.Collections;
using System.Collections.Generic;
using Systems.Audio;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using AudioType = Systems.Audio.AudioType;

public class Goal : MonoBehaviour
{
    SystemAudioManager Se;//SEを鳴らすためのスクリプト
    StageManager StageManager;
    private GameObject GoalCircle;
    private GameObject PlayerObj;
   
    private void Start()
    {
        GoalCircle = GameObject.Find("GoalCircle");
        GoalCircle.transform.DORotate(new Vector3(0, 0, -360), 2f, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
        GoalCircle.transform.DOScale(new Vector3(0.35f, 0.35f, 0.35f), 1.2f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
        Se = FindObjectOfType<SystemAudioManager>();
        StageManager = FindObjectOfType<StageManager>();
        if (Se == null) Debug.LogError("Sesystemが実装されていません");
        if (StageManager == null) Debug.LogError("StageManagerが実装されていません");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            PlayerObj = other.gameObject;
            PlayerObj.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            PlayerObj.GetComponent<Rigidbody2D>().simulated = false;
            Debug.Log(PlayerObj);
            
            StartCoroutine(Goalanimation());
        }
    }

    private void PlayBoundSe(AudioType type)
    {
        if (Se != null) Se.ShotSe(type);
    }

    private IEnumerator Goalanimation()
    {
        Debug.Log("goalAnime");
        var dis = Vector3.Distance(PlayerObj.transform.position, transform.position);
        var PlayerPos = (PlayerObj.transform.position - transform.position).normalized;
        for (int i = 0; i < 90; i++)
        {
            float temp = 1f * i * 4 / 360;
            PlayerObj.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f) * (1f - 1f* i / 90);
            var GoalPlayerPos = new Vector3(PlayerPos.x * dis * (1f - temp) * Mathf.Sin(temp * 15), PlayerPos.x * dis * (1f - temp) * Mathf.Cos(temp * 15), 0) + transform.position;
            Debug.Log(Mathf.Sin(i * 4 / 360));
            PlayerObj.transform.position = GoalPlayerPos;
            yield return new WaitForFixedUpdate();
        }
        var color = PlayerObj.GetComponent<SpriteRenderer>();
        color.color = new Color(0, 0, 0, 0);
        Destroy(this.gameObject);
        StageManager.stageClear();
        switch (Se.type)
        {
            case SystemAudioManager.SEtype.metal:
                PlayBoundSe(AudioType.MGoal);
                break;
            case SystemAudioManager.SEtype.fantasy:
                PlayBoundSe(AudioType.FGoal);
                break;
            case SystemAudioManager.SEtype.wood:
                PlayBoundSe(AudioType.WGoal);
                break;
            case SystemAudioManager.SEtype.cyber:
                PlayBoundSe(AudioType.SGoal);
                break;
            case SystemAudioManager.SEtype.normal:
                PlayBoundSe(AudioType.Goal);
                break;
        }
    }

}
