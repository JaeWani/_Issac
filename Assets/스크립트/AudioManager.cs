using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] AudioSource[] audioSource;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void TearDestroySound(AudioClip audio) 
    {
        audioSource[0].clip = audio;
        audioSource[0].Play();
    }
    public void TearFireSound(AudioClip audio) 
    {
        audioSource[1].clip = audio;
        audioSource[1].Play();
    }
    public void DoorSounds(AudioClip audio) 
    {
        audioSource[3].clip = audio;
        audioSource[3].Play();
    }
    public IEnumerator UseIntroBgm(AudioClip intro, AudioClip bgm,float volume) 
    {
        if (volume < 0f) volume = 0f;
        else if (volume > 1f) volume = 1f;
        audioSource[2].PlayOneShot(intro, volume);
        yield return new WaitForSeconds(intro.length);
        audioSource[2].loop = true;
        audioSource[2].PlayOneShot(bgm, volume);
    }
}
