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
        GameManager._instance.AdjustAudioInTime(GameManager._instance.BgAudioSource, GameManager._instance.BgAudioVolumToZeroDeleta, true);      
    }
}
