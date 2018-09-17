using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TheaterCameraControl : MonoBehaviour {

    private GameObject zuo, you, bubble;
    private float mid;
    private bool isLocked = false;
    private float offset;
    public GameObject switchAnim;
	// Use this for initialization
	void Start () {
        bubble = GameObject.Find("bubble");
        zuo = GameObject.Find("zuo");
        you = GameObject.Find("you");
        mid = zuo.transform.position.x + you.transform.position.x;
        mid /= 2;
        offset = Camera.main.transform.position.x - GameObject.Find("Player").transform.position.x;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (!GlobalTool.reenter && !isLocked && Mathf.Abs(Camera.main.transform.position.x - mid) < 0.1)
        {
            bubble.transform.position = GameManager._instance.Player.transform.position + new Vector3(0, 2.2f, 0);
            for (int i = 0; i < 2; ++i)
            {
                bubble.transform.GetChild(i).gameObject.GetComponent<Scene22AlphaControl>().ChangeVisible(true);
                GameManager._instance.Player.GetComponent<PlayerControl>().PauseMove();
                GameManager._instance.ReleaseControl();
            }
            isLocked = true; 
        }
        if (GlobalTool.reenter && GlobalTool.reenterNotHandled)
        {
            //第二次进入

            GameManager._instance.BackGroundAudio.GetComponent<Level2BackGroundAudioEnter>().ChangeLevel2Audio();

            GlobalTool.reenterNotHandled = false;
            zuo.GetComponent<Animation>().Play("zuofang");
            you.GetComponent<Animation>().Play("youfang");

            Vector3 tmp = Camera.main.transform.position;
            tmp.x = mid;
            Camera.main.transform.position = tmp;
            Invoke("SetOldMan", 1.5f);
            Invoke("OpenCurtain", 2);
        }
	}

    public void CloseCurtain()
    {
        zuo.GetComponent<Animation>().Play("zuofang");
        you.GetComponent<Animation>().Play("youfang");
        Invoke("HideOldManAndOpen", 2);
    }

    void SetOldMan()
    {
        Vector3 tmp = GameObject.Find("Player").transform.position;
        tmp.x = mid - offset;
        GameObject.Find("Player").transform.position = tmp;
    }

    void OpenCurtain()
    {
        zuo.GetComponent<Animation>().Play("zuosuo");
        you.GetComponent<Animation>().Play("yousuo");
    }

    void HideOldManAndOpen()
    {
        GlobalTool.Hide(GameObject.Find("Player"));
        zuo.GetComponent<Animation>().Play("zuosuo");
        you.GetComponent<Animation>().Play("yousuo");
        GlobalTool.Blackout();
        Invoke("Next", 2);
    }

    void Next()
    {
        SceneManager.LoadScene("Level2Recall");
        GlobalTool.justOpened = true;
    }
}

public partial class GlobalTool
{
    public static bool reenter = false;
    public static bool reenterNotHandled = false;
}