using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchLevelAnimation : MonoBehaviour
{
    private float VolumDownV = 0.0f;

    private float VolumDownCount = 20.0f;

    private float VTime;

    public void ShowText()
    {
        GameManager._instance.SwitchLevelText.SetActive(true);
    }

    public void SwitchLevel()
    {
        GameManager._instance.ChangeScene();
    }

    public void SubBgAudio()
    {
        GameManager._instance.SubAudioInTime(GameManager._instance.BgAudioSource, GameManager._instance.BgAudioVolumToZeroDeleta);
        //float v     = GameManager._instance.BgAudioSource.volume;
        //float time  = GameManager._instance.BgAudioVolumToZeroDeleta;

        //VTime = time / VolumDownCount;
        //VolumDownV = v / VolumDownCount;

        //StartCoroutine(RunSubBgAudio());
    }

    //IEnumerator RunSubBgAudio()
    //{      

    //    while (GameManager._instance.BgAudioSource.volume > 0)
    //    {
    //        print(" RunSubBgAudio :" + GameManager._instance.BgAudioSource.volume);

    //        GameManager._instance.BgAudioSource.volume -= VolumDownV;

    //        yield return new WaitForSeconds(VTime);
    //    }
    //}
}
