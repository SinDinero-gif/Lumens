using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace Systems.Managers.Audio
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance { get; private set; }

        [SerializeField] private AudioMixer audioMixer;

        [SerializeField] private AudioSource musicSource;
        [SerializeField] private AudioSource sfxSource;
        
        [SerializeField] private AudioClip[] musicClips;
        [SerializeField] private AudioClip[] sfxClips;
        
        private Dictionary<string, AudioClip> musicLibrary = new Dictionary<string, AudioClip>();
        private Dictionary<string, AudioClip> sfxLibrary = new Dictionary<string, AudioClip>();

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
                InitializeLibraries();
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void InitializeLibraries()
        {
            foreach (AudioClip clip in musicClips)
            {
                musicLibrary[clip.name] = clip;
            }

            foreach (AudioClip clip in sfxClips)
            {
                sfxLibrary[clip.name] = clip;
            }
        }

        public void PlayMusic(string clipName, bool loop = true)
        {
            if (musicLibrary.TryGetValue(clipName, out AudioClip clip))
            {
                musicSource.clip = clip;
                musicSource.loop = loop;
                musicSource.Play();
            }
            else
            {
                Debug.LogWarning($"Music Clip {clipName} not found");
            }
        }

        public void PlaySfx(string clipName)
        {
            if (sfxLibrary.TryGetValue(clipName, out AudioClip clip))
            {
                sfxSource.PlayOneShot(clip);
            }
            else
            {
                Debug.LogWarning($"SFX Clip {clipName} not found");
            }
        }

        public void SetMasterVolume(float value)
        {
            audioMixer.SetFloat("MasterVolume", Mathf.Log10(value) * 20);
        }

        public void SetMusicVolume(float value)
        {
            audioMixer.SetFloat("MusicVolume", Mathf.Log10(value) * 20);
        }

        public void SetSfxVolume(float value)
        {
            audioMixer.SetFloat("SfxVolume", Mathf.Log10(value) * 20);
        }

        public void StopMusic()
        {
            musicSource.Stop();
        }
    }
}
