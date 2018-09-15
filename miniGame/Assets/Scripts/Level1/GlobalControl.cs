using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalControl : MonoBehaviour {

    public AudioSource uiBgm, s1bgm;
	// Use this for initialization
	void Start () {
        GlobalTool.scene1StartHandled = false;
        uiBgm = GameObject.Find("UIBgm").GetComponent<AudioSource>();
        s1bgm = GameObject.Find("BackGroundAudio").GetComponent<AudioSource>();
        uiBgm.loop = true;
        StartUiBgm();
    }
	
	// Update is called once per frame
	void Update () {
		if (!GlobalTool.scene1StartHandled)
        {
            if (!GlobalTool.needUi)
            {
                Camera.main.transform.position = new Vector3(-23.23f, -1.5f, -50);
                GlobalTool.scene1StartHandled = true;
                GameManager._instance.Player.GetComponent<PlayerControl>().StartMove();
                GameManager._instance.GetControl();
                StartS1Bgm();
            } else
            {
                StartUiBgm();
            }
        }
	}

    public void StartS1Bgm()
    {
        uiBgm.Stop();
        s1bgm.Play();
    }

    public void StartUiBgm()
    {
        uiBgm.Play();
        s1bgm.Stop();
    }
}
