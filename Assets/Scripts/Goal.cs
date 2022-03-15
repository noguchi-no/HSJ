using System.Collections;
using System.Collections.Generic;
using Systems.Audio;
using UnityEngine;
using AudioType = Systems.Audio.AudioType;

public class Goal : MonoBehaviour
{
    SystemAudioManager Se;//SEを鳴らすためのスクリプト
    private void Start()
    {

        Se = FindObjectOfType<SystemAudioManager>();
        if (Se == null) Debug.LogError("Sesystemが実装されていません");
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
        }
    }

    private void PlayBoundSe(AudioType type)
    {
        if (Se != null) Se.ShotSe(type);
    }
}
