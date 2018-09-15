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

    public AudioClip HuiYiHouIng;
    public AudioClip HuiYiHou;

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

        StartCoroutine(OnChangeHuiYi1());
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

        StartCoroutine(OnChangeHuiYi2());
    }

    private IEnumerator OnChangeHuiYi2()
    {
        while(BgAudioSource.isPlaying)
        {
            yield return new WaitForSeconds(0.5f);
        }

        if (BgAudioSource.clip == HuiYi1)
        {
            BgAudioSource.volume = 1.0f;
            BgAudioSource.clip = HuiYi2;
            BgAudioSource.Play();
            BgAudioSource.loop = true;
        }
        else
        {
            BgAudioSource.loop = true;
            BgAudioSource.Play();
        }
           
    }

    public void ChangeHuiYi3()
    {
        print("ChangeHuiYi3 ChangeHuiYi3");

        BgAudioSource.loop = false;

        StartCoroutine(OnChangeHuiYi3());
    }

    private IEnumerator OnChangeHuiYi3()
    {
        while (BgAudioSource.isPlaying)
        {
            yield return new WaitForSeconds(0.5f);
        }

        if(BgAudioSource.clip== HuiYi2)
        {
            BgAudioSource.volume = 1.0f;
            BgAudioSource.clip = HuiYi3;
            BgAudioSource.Play();
            BgAudioSource.loop = true;
        }
        else
        {
            BgAudioSource.loop = true;
            BgAudioSource.Play();
        }
    }

    public void ChangeHuiYiHouing()
    {
        BgAudioSource.loop = false;

        //OnChangeHuiYiHouing();

        StartCoroutine(OnChangeHuiYiHouing());
    }
    
    private IEnumerator OnChangeHuiYiHouing()
    {
        print("OnChangeHuiYiHouing OnChangeHuiYiHouing");

        GameManager._instance.AdjustAudioInTime(BgAudioSource, 3, true);

        yield return new WaitForSeconds(1.0f);

        BgAudioSource.volume = 0.1f;
        BgAudioSource.clip = HuiYiHouIng;
        BgAudioSource.Play();
        BgAudioSource.loop = false;

        ChangeHuiYiHou();        
    }

    private void ChangeHuiYiHou()
    {
        GameManager._instance.AdjustAudioInTime(BgAudioSource, 3, false);

        StartCoroutine(OnChangeHuiYiHou());
    }

    private IEnumerator OnChangeHuiYiHou()
    {
        print("OnChangeHuiYiHou OnChangeHuiYiHou");

        while (BgAudioSource.isPlaying)
        {
            yield return new WaitForSeconds(0.5f);
        }

        BgAudioSource.volume = 1.0f;
        BgAudioSource.clip = HuiYiHou;
        BgAudioSource.Play();
        BgAudioSource.loop = true;
    }
}
