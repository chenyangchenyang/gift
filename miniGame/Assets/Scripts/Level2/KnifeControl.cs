﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KnifeControl : WrappedBehaviour {

    public GameObject XiaoMuTouAudio;

    private AudioSource AudioSourceMuTou;

    private Vector3 offset;
    private Vector3 startPos;
    private GameObject wood;
    private float swipeDist;
    private float timePast;
    public int woodState = 1;
    private float timeToPast = 4;
    private bool reseted = false;
	// Use this for initialization
	void Start () {
        startPos = transform.position;
        wood = GameObject.Find("WoodHand");
        timePast = -3;

        AudioSourceMuTou = XiaoMuTouAudio.GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void Update ()
    {
        timePast += Time.deltaTime;
	}

    private void OnMouseDown()
    {
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDrag()
    {
        if (!reseted && woodState == 1)
        {
            reseted = true;
            timePast = 0;
        }
        if (!reseted && woodState == 3)
        {
            timePast = 3;
            reseted = true;
        }
        if (woodState > 3)
        {
            timeToPast = 2;
        }
        Vector3 tmp = offset + Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (timePast >= timeToPast && (wood.transform.position.x - 7.6 <= transform.position.x &&
                transform.position.x <= wood.transform.position.x - 2.6))
        {
            // TODO:播放木头声音

            //if(!AudioSourceMuTou.isPlaying)
            {
                AudioSourceMuTou.Play();
            }

            swipeDist += Vector3.Distance(tmp, transform.position);
            if (swipeDist > 2)
            {
                timePast = 0;
                swipeDist = 0;
                if (woodState == 1)
                {
                    ShowS2();
                }
                if (woodState == 2)
                {
                    ShowS3();
                    // 切换到离别场景
                    Invoke("Blackout", 3);
                    Invoke("ShowMakeMutou", 4);
                    Invoke("HideMakeMutou", 5);
                    Invoke("Next", 5);
                    GlobalTool.needCheckKnifeIdle = false;
                }
                woodState += 1;
                if (woodState <= 5) 
                    wood.GetComponent<SpriteRenderer>().sprite = 
                        Resources.Load("img/第二关场景3/mutou" + woodState, new Sprite().GetType()) as Sprite;
                if (woodState == 5)
                {
                    Invoke("ChangeBG5",2.0f);
                    // 切换到下一个场景
                    Invoke("Blackout", 2);
                    Invoke("Next2", 4);
                    GlobalTool.reenter = true;
                    GlobalTool.reenterNotHandled = true;
                    GlobalTool.needCheckKnifeIdle = false;
                }
            }
        }

        transform.position = tmp;
    }

    public void ChangeBG5()
    {
        GameManager._instance.BackGroundAudio.GetComponent<Level2BackGroundAudio>().ChangeHuiYi5();
    }

    void ShowMakeMutou()
    {
        var makemutou = GameObject.Find("makemutou");
        makemutou.transform.position = Camera.main.transform.position + new Vector3(0, 0, 10);
        makemutou.GetComponent<Scene22AlphaControl>().ChangeVisible(true);
    }

    void HideMakeMutou()
    {
        GameObject.Find("makemutou").GetComponent<Scene22AlphaControl>().ChangeVisible(false);
    }


    private void OnMouseUp()
    {
        transform.position = startPos;
    }

    void Next()
    {

        SceneManager.LoadScene("Level2Scene5");
    }

    void Next2()
    {
        SceneManager.LoadScene("Level2Inside");
    }

    void ShowS2()
    {
        GameObject.Find("sentence2").GetComponent<Scene22AlphaControl>().ChangeVisible(true);
        Invoke("HideS2", 2);
    }
    void HideS2()
    {
        GameObject.Find("sentence2").GetComponent<Scene22AlphaControl>().ChangeVisible(false);
    }
    void ShowS3()
    {
        GameObject.Find("sentence3").GetComponent<Scene22AlphaControl>().ChangeVisible(true);
        Invoke("HideS3", 2);
    }

    void HideS3()
    {
        GameObject.Find("sentence3").GetComponent<Scene22AlphaControl>().ChangeVisible(false);

    }
}

public partial class GlobalTool
{ 
    static private bool HasKey(string key)
    {
        return Saves.ContainsValue(key);
    }

    static public void DeleteAll()
    {
        Saves.Clear();
    }


    static public void SetString(string key, string value)

    {
        Saves.Remove(key);
        Saves.Add(key, value);
    }

    static public string GetString(string key)

    {
        return Saves[key];
    }

    static public Dictionary<string, string> Saves = new Dictionary<string, string>();
}