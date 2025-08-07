using System;
using UnityEngine;
using UnityEngine.Audio;


namespace Believe.Games.Studios
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance;
        public Sound[] sounds;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }

            foreach (Sound s in sounds)
            {
                s.Source = gameObject.AddComponent<AudioSource>();
                s.Source.clip = s.Clip;
                s.Source.loop = s.IsLoop;
                s.Source.outputAudioMixerGroup = s.mixer;
                s.Source.pitch = s.Pitch;
                s.Source.volume = s.Volume;
                s.Source.bypassReverbZones = s.ByPassEffect;


            }

        }


        public void PlaySound(string Name)
        {
            Sound s = Array.Find(sounds, Sound => Sound.ClipName == Name);
            s.Source.Play();
        }
    }
    [System.Serializable]
    public class Sound
    {
        public string ClipName;
        public AudioClip Clip;
        [HideInInspector]
        public AudioSource Source;
        public bool ByPassEffect;
        public bool IsLoop;
        [Range(0, 1)]
        public float Volume;
        [Range(-3, 3)]
        public float Pitch;
        public AudioMixerGroup mixer;
    }
}
