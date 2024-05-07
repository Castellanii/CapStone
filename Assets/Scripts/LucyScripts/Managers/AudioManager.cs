using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public List<AudioSource> sources = new List<AudioSource>();

    void Singleton()
    {
        if (instance != null && instance != this)
        {
            Destroy(instance);
        }
        instance = this;
    }


    private void Awake()
    {
        Singleton();
        if(PlayerPrefs.GetInt("gameStatus") == (int)GameStatus.StartGame)
        {
            PlayAudio(6);
        }
    }


    public void PlayAudio(int index)
    {
        if (sources != null && sources.Count > 0)
        {
            sources[index].Play();
        }
    }


    public void PlayAudioForDuration(AudioSource source, float duration)
    {
        if (source != null)
        {
            source.Play();
            StartCoroutine(StopAudioAfterDuration(source, duration));
        }
    }

    private IEnumerator StopAudioAfterDuration(AudioSource source, float duration)
    {
        yield return new WaitForSeconds(duration);
        if (source.isPlaying)
        {
            source.Stop();
        }
    }

    public void PlayAudioForDuration(AudioSource source, float duration, float startTime, float volumeMultiplier)
    {
        if (source != null)
        {
            Debug.Log("Start" + source.volume);
            Debug.Log("multiplier" + volumeMultiplier);
            source.time = startTime;
            source.volume *= volumeMultiplier;
            Debug.Log("end" + source.volume);
            source.Play();
            StartCoroutine(StopAudioAfterDuration(source, duration));
        }
    }
}
