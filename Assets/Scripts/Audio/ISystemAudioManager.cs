using UnityEngine;

namespace Systems.Audio
{
    public interface ISystemAudioManager
    {
        void ShotBgm(AudioType audioType);
        void ShotSe(AudioType audioType);
    }
}