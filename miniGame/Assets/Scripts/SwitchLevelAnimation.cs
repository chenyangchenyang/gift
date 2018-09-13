using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchLevelAnimation : MonoBehaviour
{
    public void ShowText()
    {
        GameManager._instance.SwitchLevelText.SetActive(true);
    }

    public void SwitchLevel()
    {
        GameManager._instance.ChangeScene();
    }
}
