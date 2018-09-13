using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLevelAnimation : MonoBehaviour
{
    public void StartLevel()
    {
        GameManager._instance.StartLevelAnimation.SetActive(false);
    }
}
