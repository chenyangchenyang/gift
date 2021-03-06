﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuiyiControl : WrappedBehaviour
{

    public GameObject player;
    public GameObject huiyiFlag, wallpaper;
    public GameObject[] soul = new GameObject[8];
    public GameObject clickBox;
    public float originSize;
    public Vector3 originPos;
    private const float targetSize = 1.153179f;
    private Vector3 targetPos = new Vector3(-15.08f, -6.79f, -50);
    private int soulId = 0;
    // Use this for initialization
    void Start()
    {
        wallpaper = GameObject.Find("wallpaper");
        player = GameObject.Find("Player");
        huiyiFlag = GameObject.Find("huiyiFlag");
        for (int i = 0; i < 8; ++i)
        {
            soul[i] = GameObject.Find("soul" + (i + 1));
        }
        clickBox = GameObject.Find("ClickBox");
    }

    // Update is called once per frame
    void Update()
    {
        if (!showed)
        {
            if (Mathf.Abs(GameManager._instance.Player.transform.position.x - huiyiFlag.transform.position.x) < 0.1)
            {
                
                GameManager._instance.BackGroundAudio.GetComponent<Level4BackGroundAudio>().ChangeHuiYi1();
                originSize = Camera.main.orthographicSize;
                originPos = Camera.main.transform.position;
                sizeDiff = targetSize - Camera.main.orthographicSize;
                posDiff = targetPos - Camera.main.transform.position;
                showed = true;
                pullIn = true;
                Camera.main.GetComponent<CameraControl>().lookGameObject = null;
                GameManager._instance.Player.GetComponent<PlayerControl>().PauseMove();
                GameManager._instance.ReleaseControl();
                Invoke("Blackout", 2.8f);
            }   
        }
        if (pullIn && (!sizeok || !posok))
        {
            if (!sizeok)
            {
                float size = Camera.main.orthographicSize;
                size += 0.3f * sizeDiff * Time.deltaTime;
                Camera.main.orthographicSize = size;
                if (Mathf.Abs(size - targetSize) < 0.1)
                {
                    Camera.main.orthographicSize = targetSize;
                    sizeok = true;
                }
            }
            if (!posok)
            {
                Vector3 pos = Camera.main.transform.position;
                pos += 0.3f * posDiff * Time.deltaTime;
                Camera.main.transform.position = pos;
                print(Vector3.Distance(pos, targetPos));
                if (Vector3.Distance(pos, targetPos) < 0.05)
                {
                    Camera.main.transform.position = targetPos;
                    posok = true;
                }
            }
            if (posok && sizeok)
            {
                Invoke("StartSoul", 0);
            }
        }
    }
    public float sizeDiff;
    public Vector3 posDiff;
    public bool pullIn = false;
    public bool posok = false;
    public bool sizeok = false;

    void StartSoul()
    {
        soul[0].transform.position = Camera.main.transform.position + new Vector3(0, 0, 10);
        soul[0].GetComponent<Scene22AlphaControl>().ChangeVisible(true);
        clickBox.transform.position = Camera.main.transform.position + new Vector3(0, 0, 10);
        Camera.main.GetComponent<CameraControl>().lookGameObject = null;
    }

    void ShowSoul()
    {
        if (soulId == 0)
        {
            soul[soulId].transform.position = Camera.main.transform.position + new Vector3(0, 0, 10);
            soul[soulId].GetComponent<Scene22AlphaControl>().ChangeVisible(true);
        }
        if (soulId == 7)
        {
            soul[soulId].GetComponent<Scene22AlphaControl>().ChangeVisible(false);
            for (int i = 0; i < 8; ++i)
            {
                soul[i].transform.position = new Vector3(-10000, -10000, 0);
            }
            Invoke("Whiteout", 2);
        }
        else
        {
            soul[soulId].GetComponent<Scene22AlphaControl>().ChangeVisible(false);
            soul[soulId + 1].transform.position = Camera.main.transform.position + new Vector3(0, 0, 10);
            soul[soulId + 1].GetComponent<Scene22AlphaControl>().ChangeVisible(true);
            Camera.main.GetComponent<CameraControl>().lookGameObject = player;
        }
        soulId++;
    }

    private bool showed = false;
}