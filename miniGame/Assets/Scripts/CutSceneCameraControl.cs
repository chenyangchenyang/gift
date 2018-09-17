using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutSceneCameraControl : MonoBehaviour {

    public Dictionary<int, GameObject> chapMap = new Dictionary<int, GameObject>();
	// Use this for initialization
	void Start () {
        chapMap[2] = GameObject.Find("chap2");
        chapMap[3] = GameObject.Find("chap3");
        chapMap[4] = GameObject.Find("chap4");
        Invoke("ShowChap", 1);
    }
	
	// Update is called once per frame
	void Update () {
	}

    void ShowChap()
    {
        chapMap[GlobalTool.nextScene].GetComponent<Scene22AlphaControl>().ChangeVisible(true);
        Invoke("HideChap", 3);
    }

    void HideChap()
    {
        chapMap[GlobalTool.nextScene].GetComponent<Scene22AlphaControl>().ChangeVisible(false);
        Invoke("ChangeScene", 1);
    }

    void ChangeScene()
    {
        switch (GlobalTool.nextScene)
        {
            case 2:
                SceneManager.LoadScene("Level2Outside");
                return;
            case 3:
                SceneManager.LoadScene("Level3");
                return;
            case 4:
                SceneManager.LoadScene("Level4");
                return;
        }
    }
}

public partial class GlobalTool
{
    public static int nextScene = 2;
}
