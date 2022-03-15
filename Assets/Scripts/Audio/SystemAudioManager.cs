using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Systems.Audio
{
    public class SystemAudioManager : MonoBehaviour, ISystemAudioManager
    {
        public enum SEtype
        {
            metal,
            fantasy,
            wood,
            cyber,
            normal
        }

        public SEtype type;
        [SerializeField] private AudioSource bgmSource;
        [SerializeField] private List<AudioClip> bgmList;

        [SerializeField] private AudioSource seSource;
        [SerializeField] private List<AudioClip> seList;

        public void ShotBgm(AudioType audioType)
        {
            bgmSource.loop = true;
            bgmSource.clip = bgmList.First(bgm => bgm.name == audioType.ToString());
            bgmSource.Play();
        }

        public void ShotSe(AudioType audioType)
        {
            var se = seList.First(se => se.name == audioType.ToString());
            Debug.Log(se +"‚ð–Â‚ç‚µ‚½");
            seSource.PlayOneShot(se);
        }
    }
}