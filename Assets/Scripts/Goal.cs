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
        Debug.Log(other.gameObject.name);

        if (other.gameObject.name == "Player")
        {
            Debug.Log("GOAL!!!");
            Destroy(this.gameObject); 
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
            StageManager.stageClear();
        }
    }

    private void PlayBoundSe(AudioType type)
    {
        if (Se != null) Se.ShotSe(type);
    }

}
