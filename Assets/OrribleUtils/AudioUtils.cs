using System.Collections;
using UnityEngine;

namespace Assets.OrribleUtils
{
    public static class AudioUtils
    {
        public static IEnumerator FadeOut(AudioSource audioSource, float fadeTime)
        {
            // From: https://forum.unity.com/threads/fade-out-audio-source.335031/

            float startVolume = audioSource.volume;

            while (audioSource.volume > 0)
            {
                audioSource.volume -= startVolume * Time.deltaTime / fadeTime;

                yield return null;
            }

            audioSource.Stop();
            audioSource.volume = startVolume;
        }
    }
}
