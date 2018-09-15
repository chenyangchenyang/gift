using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level4BackGroundAudio : MonoBehaviour
{
    private AudioSource BgAudioSource;

    private string path = "Audios/Level4/";

    public AudioClip HuiYi1;
    public AudioClip HuiYi2;
    public AudioClip HuiYi3;

    public float TimeForBgToHuiYi1 = 3.0f;

    void Start()
    {
        BgAudioSource = GetComponent<AudioSource>();

        GameManager._instance.ReStartAudio(BgAudioSource, path);
    }

    private void Update()
    {

    }


    public void ChangeHuiYi1()
    {
        BgAudioSource.loop = true;

        GameManager._instance.AdjustAudioInTime(BgAudioSource, TimeForBgToHuiYi1, true);

        StartCoroutine("OnChangeHuiYi1");
    }

    private IEnumerator OnChangeHuiYi1()
    {
        yield return new WaitForSeconds(TimeForBgToHuiYi1);

        BgAudioSource.volume = 1.0f;

        BgAudioSource.clip = HuiYi1;
        BgAudioSource.Play();
    }


    public void ChangeHuiYi2()
    {
        BgAudioSource.loop = false;
    }
}
