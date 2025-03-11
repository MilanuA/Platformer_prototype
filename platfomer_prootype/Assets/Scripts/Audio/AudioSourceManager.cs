using System;
using UnityEngine;

namespace Audio
{
    public class AudioSourceManager : MonoBehaviour
    {
        public static Action OnPlayCollectAudio;

        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();

            if (!_audioSource)
                Debug.LogError("Audio source is null.");
        }

        private void OnEnable()
        {
            OnPlayCollectAudio += PlayCollectAudio;
        }

        private void OnDisable()
        {
            OnPlayCollectAudio -= PlayCollectAudio;
        }

        private void PlayCollectAudio()
        {
            _audioSource.Play();
        }
    }
}
