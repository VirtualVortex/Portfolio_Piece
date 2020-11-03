using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager inst;

    private void Awake()
    {
        //Singleton
        if (inst == null)
            inst = this;
        else if (inst != this)
            Destroy(FindObjectOfType<SceneChanger>().gameObject);

        //DontDestroyOnLoad(this.gameObject);
    }

    public void SwitchMusic(AudioSource audioSource, AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }

    public void PlayLoop(AudioSource audioSource, AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.loop = true;
        audioSource.Play();
    }

    public void PlayOnce(AudioSource audioSource, AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.loop = false;
        audioSource.Play();
    }
}
