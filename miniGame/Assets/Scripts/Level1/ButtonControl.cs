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
    
    private GameObject btStart, btContinue;
    private GameObject[] leaves = new GameObject[4];
    private GameObject[] chapters = new GameObject[4];
    private int nextId = 1;
	// Use this for initialization
	void Start () {
        btStart = GameObject.Find("START");
        btContinue = GameObject.Find("CONTINUE");
        GameManager._instance.PlayerControlUI.SetActive(false);
        for (int i = 0; i < 4; ++i)
        {
            leaves[i] = GameObject.Find("leaf" + (i + 1));
            chapters[i] = GameObject.Find("chapter" + (i + 1));
        }
        for (int i = 0; i < 4; ++i)
        {
            GlobalTool.Hide(chapters[i]);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        transform.localScale = new Vector3(1.1f, 1.1f, 1);
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
        }
        if (type > 10)
        {
            nextId = type - 10;
        }
        
        if (type < 2)
        {
            btStart.GetComponent<Scene22AlphaControl>().ChangeVisible(false);
            btContinue.GetComponent<Scene22AlphaControl>().ChangeVisible(false);
            if (type == 1)
            {
                for (int i = 0; i < 4; ++i)
                {
                    GlobalTool.Show(chapters[i]);
                    chapters[i].GetComponent<Scene22AlphaControl>().ChangeVisible(true);
                }
            }
        }

        if (type > 10)
        {
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

    void ChangeScene()
    {
        switch (nextId)
        {
            case 1:
                var cameraControl = Camera.main.GetComponent<CameraControl>();
                cameraControl.needMove = true;
                var tmpPos = cameraControl.transform.position;
                tmpPos.y -= 15.8f;
                cameraControl.destination = tmpPos;
                GameManager._instance.PlayerControlUI.SetActive(true);
                return;
            default:
                Invoke("Blackout", 0);
                Invoke("ExternalScene", 2);
                return;
        }
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
}
