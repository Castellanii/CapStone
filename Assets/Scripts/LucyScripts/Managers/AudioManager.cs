using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    private AudioSource collectCoinAudio;

    public static AudioManager instance;

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
        collectCoinAudio = this.GetComponent<AudioSource>();
    }


    public void PlayCollectCoinAudio()
    {
        collectCoinAudio.Play();
    }
}
