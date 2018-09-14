using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchLevelAnimation2 : MonoBehaviour {

    public void ShowText()
    {
        GameManager._instance.SwitchLevelText.SetActive(true);
    }

    public void SwitchLevel()
    {
        SceneManager.LoadScene("第二关");
        GlobalTool.justOpened = true;
    }
}
