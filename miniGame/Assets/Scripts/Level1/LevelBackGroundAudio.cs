using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBackGroundAudio : MonoBehaviour
{
    private AudioSource BgAudioSource;

    private string path = "Audios/Level1/";

    void Start ()
    {
        BgAudioSource = GetComponent<AudioSource>();

        GameManager._instance.ReStartAudio(BgAudioSource, path);
    }
}
