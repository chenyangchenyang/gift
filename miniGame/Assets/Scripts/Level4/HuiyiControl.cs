using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuiyiControl : WrappedBehaviour
{

    public GameObject player;
    public GameObject huiyiFlag;
    public GameObject[] soul = new GameObject[8];
    public GameObject clickBox;
    private int soulId = 0;
    // Use this for initialization
    void Start()
    {
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
            if (Mathf.Abs(Camera.main.transform.position.x - huiyiFlag.transform.position.x) < 0.1)
            {

                GameManager._instance.BackGroundAudio.GetComponent<Level4BackGroundAudio>().ChangeHuiYi1();


                showed = true;
                Invoke("Blackout", 0);
                soul[0].transform.position = Camera.main.transform.position + new Vector3(0, 0, 10);
                soul[0].GetComponent<Scene22AlphaControl>().ChangeVisible(true);
                clickBox.transform.position = Camera.main.transform.position + new Vector3(0, 0, 10);
                Camera.main.GetComponent<CameraControl>().lookGameObject = null;
            }   
        }
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