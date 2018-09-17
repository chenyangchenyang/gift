using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2BackGroundAudio : MonoBehaviour
{
    public AudioClip HuiYi2;
    public AudioClip HuiYi_MoYu;
    public AudioClip HuiYi_MuDiao;
    public AudioClip HuiYi_LiBie;
    [HideInInspector]
    public AudioSource BgAudioSource;

	// Use this for initialization
	void Start ()
    {
        BgAudioSource = GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void Update ()
    {
        
	}

    public void ChangeHuiYi2()
    {
        BgAudioSource.loop = false;
       // GameManager._instance.AdjustAudioInTime(BgAudioSource, 3, true);

        StartCoroutine(OnChangeHuiYi2());       
    }

    private IEnumerator OnChangeHuiYi2()
    {
        while (BgAudioSource.isPlaying)
        {
            yield return new WaitForSeconds(0.3f);
        }

        BgAudioSource.Stop();

        BgAudioSource.volume = 1.0f;
        BgAudioSource.clip = HuiYi2;
        BgAudioSource.Play();
        BgAudioSource.loop = true;
    }

    public void ChangeHuiYi3()
    {
        BgAudioSource.loop = false;
        //GameManager._instance.AdjustAudioInTime(BgAudioSource, 3, true);

        StartCoroutine(OnChangeHuiYi3());
    }

    private IEnumerator OnChangeHuiYi3()
    {
        while (BgAudioSource.isPlaying)
        {
            yield return new WaitForSeconds(0.3f);
        }

        BgAudioSource.Stop();

        BgAudioSource.volume = 1.0f;
        BgAudioSource.clip = HuiYi_MoYu;
        BgAudioSource.Play();
        BgAudioSource.loop = true;
    }

    public void ChangeHuiYi4()
    {
        BgAudioSource.loop = false;
        //GameManager._instance.AdjustAudioInTime(BgAudioSource, 3, true);

        StartCoroutine(OnChangeHuiYi4());
    }

    private IEnumerator OnChangeHuiYi4()
    {
        while(BgAudioSource.isPlaying)
        {
            yield return new WaitForSeconds(0.3f);
        }        

        BgAudioSource.Stop();
        BgAudioSource.volume = 1.0f;
        BgAudioSource.clip = HuiYi_MuDiao;
        BgAudioSource.Play();
        BgAudioSource.loop = true;
    }

    public void ChangeHuiYi5()
    {
        BgAudioSource.loop = true;
        BgAudioSource.clip = HuiYi_LiBie;
        BgAudioSource.volume = 1.0f;
        BgAudioSource.Play();       
    }

    public void ChangeHuiYi5Down()
    {
        BgAudioSource.loop = false;
        GameManager._instance.AdjustAudioInTime(BgAudioSource, 3, true);
    }
}
