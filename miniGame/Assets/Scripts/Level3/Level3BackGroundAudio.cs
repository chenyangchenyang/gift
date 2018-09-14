using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3BackGroundAudio : MonoBehaviour
{
    private AudioSource BgAudioSource;

    private string path = "Audios/Level3/alone/";

    public AudioClip NextAudioClip;

    void Start()
    {
        BgAudioSource = GetComponent<AudioSource>();

        GameManager._instance.ReStartAudio(BgAudioSource, path);

        GameManager._instance.AdjustAudioInTime(BgAudioSource, 5.0f, false);
    }

    private void Update()
    {
        if(!BgAudioSource.isPlaying)
        {
            BgAudioSource.clip = NextAudioClip;

            BgAudioSource.Play();

            BgAudioSource.loop = true;
        }
    }
}
