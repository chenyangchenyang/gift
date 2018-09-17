using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2BackGroundAudioEnter : MonoBehaviour
{
    public AudioClip BGAudio;
    
    public void ChangeLevel2Audio()
    {
        AudioSource audioSource= GetComponent<AudioSource>();
        audioSource.clip = BGAudio;
        audioSource.loop = true;
        audioSource.volume = 1.0f;
        audioSource.Play();
    }
}
