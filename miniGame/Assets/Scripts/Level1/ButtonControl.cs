using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonControl : WrappedBehaviour {

    /*
     * 0 - 开始
     * 1 - 继续
     * 11 - 第一章
     * 12 - 第二章
     * 13 - 第三章
     * 14 - 第四章
     */ 
    public int type;

    private AudioSource buttonAudio;
    private GameObject btStart, btContinue, newbee, gift;
    private GameObject[] leaves = new GameObject[4];
    private GameObject[] chapters = new GameObject[4];
    private int nextId = 1;
	// Use this for initialization
	void Start () {
        gift = GameObject.Find("gift");
        btStart = GameObject.Find("START");
        btContinue = GameObject.Find("CONTINUE");
        for (int i = 0; i < 4; ++i)
        {
            leaves[i] = GameObject.Find("leaf" + (i + 1));
            chapters[i] = GameObject.Find("chapter" + (i + 1));
        }
        for (int i = 0; i < 4; ++i)
        {
            GlobalTool.Hide(chapters[i]);
        }
        newbee = GameObject.Find("newbee");
        buttonAudio = GameObject.Find("ButtonAudio").GetComponent<AudioSource>();
        GameManager._instance.Player.GetComponent<PlayerControl>().PauseMove();
        GameManager._instance.ReleaseControl();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        transform.localScale = new Vector3(1.1f, 1.1f, 1);
        buttonAudio.Play();
    }

    private void OnMouseUp()
    {
        transform.localScale = Vector3.one;
    }

    private void OnMouseUpAsButton()
    {
        if (type == 0)
        {
            nextId = 1;
            gift.GetComponent<Scene22AlphaControl>().ChangeVisible(false);
            Invoke("ChangeScene", 1);
        }
        
        if (type < 2)
        {
            btStart.GetComponent<Scene22AlphaControl>().ChangeVisible(false);
            btContinue.GetComponent<Scene22AlphaControl>().ChangeVisible(false);
            if (type == 1)
            {
                Invoke("HideStartButton", 1);
                for (int i = 0; i < 4; ++i)
                {
                    GlobalTool.Show(chapters[i]);
                    chapters[i].GetComponent<Scene22AlphaControl>().ChangeVisible(true);
                }
            }
        }

        if (type > 10)
        {
            nextId = type - 10;
            leaves[type - 11].GetComponent<Scene22AlphaControl>().ChangeVisible(true);
            for (int i = 11; i < 15; ++i)
            {
                if (type != i)
                {
                    chapters[i - 11].GetComponent<Scene22AlphaControl>().ChangeVisible(false);
                }
            }
            Invoke("ChangeScene", 1);
        }
    }

    void HideStartButton()
    {
        btStart.transform.localScale = Vector3.zero;
        btContinue.transform.localScale = Vector3.zero;
    }

    void ChangeScene()
    {
        GlobalTool.needUi = false;
        GlobalTool.scene1StartHandled = true;
        switch (nextId)
        {
            case 1:
                gift.GetComponent<Scene22AlphaControl>().ChangeVisible(false);
                chapters[0].GetComponent<Scene22AlphaControl>().ChangeVisible(false);
                leaves[0].GetComponent<Scene22AlphaControl>().ChangeVisible(false);
                Invoke("ShowChap1Desc", 0);
                Invoke("StartScene1", 3);
                return;
            default:
                Invoke("Blackout", 0);
                Invoke("ExternalScene", 2);
                return;
        }
    }

    void StartScene1()
    {
        var cameraControl = Camera.main.GetComponent<CameraControl>();
        cameraControl.needMove = true;
        cameraControl.destination = new Vector3(-23.3f, -1.5f, -50);
        GameManager._instance.GetControl();
        GameManager._instance.Player.GetComponent<PlayerControl>().StartMove();
        GameManager._instance.GlobalControllerObject.GetComponent<GlobalControl>().StartS1Bgm();
        Invoke("ShowNewBee", 2);
    }

    void ExternalScene()
    {
        switch (nextId)
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


    void ShowNewBee()
    {
        newbee.transform.position = Camera.main.transform.position + new Vector3(0, 0, 10);
        newbee.GetComponent<Scene22AlphaControl>().ChangeVisible(true);
        newbee.GetComponent<NewbeeControl>().show = true;
        Invoke("RemoveNewBee", 4);
    }

    void RemoveNewBee()
    {
        newbee.GetComponent<Scene22AlphaControl>().ChangeVisible(false);
        Invoke("MoveOutNewbee", 2);
    }

    void MoveOutNewbee()
    {
        newbee.transform.position = new Vector3(1000, 1000, 0);
        newbee.GetComponent<NewbeeControl>().show = false;
    }

    void ShowChap1Desc()
    {
        GameObject.Find("Chap1Desc").GetComponent<Scene22AlphaControl>().ChangeVisible(true);
        Invoke("HideChap1Desc", 2.5f);
    }

    void HideChap1Desc()
    {
        GameObject.Find("Chap1Desc").GetComponent<Scene22AlphaControl>().ChangeVisible(false);
    }
}

public partial class GlobalTool
{
    public static bool scene1StartHandled = false;
    public static bool needUi = true;
    public static bool hasShownPaGuang = false;
    public static int scene1Time = 0;
}
