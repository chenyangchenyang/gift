using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickControl : WrappedBehaviour {

    private int state = 0;
    private float timePast = 0;
    private GameObject player;
    private GameObject huiyiFlag;
    private GameObject[] soul = new GameObject[8];
    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");
        huiyiFlag = GameObject.Find("huiyiFlag");
        for (int i = 0; i < 8; ++i)
        {
            soul[i] = GameObject.Find("soul" + (i + 1));
        }
        Physics2D.IgnoreLayerCollision(
            LayerMask.NameToLayer("playerBody"), LayerMask.NameToLayer("UI"));
    }
	
	// Update is called once per frame
	void Update () {
        timePast += Time.deltaTime;
	}

    private void OnMouseUpAsButton()
    {
        if (timePast > 3)
        {
            timePast = 0;
            if (state < 3)
            {
                soul[state + 1].transform.position = Camera.main.transform.position + new Vector3(0, 0, 10);
                soul[state + 1].GetComponent<Scene22AlphaControl>().ChangeVisible(true);
                ++state;
            }
            if (state == 3)
            {
                for (int i = 3; i < 8; ++i)
                {
                    Invoke("ShowSoul", (i - 3) * 3);
                }
                transform.position = new Vector3(1000, 1000, 0);


                GameManager._instance.BackGroundAudio.GetComponent<Level4BackGroundAudio>().ChangeHuiYi3();
            }

            if (2 == state)
            {
                GameManager._instance.BackGroundAudio.GetComponent<Level4BackGroundAudio>().ChangeHuiYi2();
            }

            //if(4 == state)
            //{
            //    GameManager._instance.BackGroundAudio.GetComponent<Level4BackGroundAudio>().ChangeHuiYi3();
            //}

            print("OnMouseUpAsButton :"+ state);
        }
    }

    void ShowSoul()
    {
        if (state == 7)
        {
            for (int i = 0; i < 8; ++i)
            {
                soul[i].GetComponent<Scene22AlphaControl>().ChangeVisible(false);
            }
            Invoke("ResumeFromRecall", 2);
        } 
        else
        {
            soul[state + 1].transform.position = Camera.main.transform.position + new Vector3(0, 0, 10);
            soul[state + 1].GetComponent<Scene22AlphaControl>().ChangeVisible(true);
            ++state;
        }
    }

    void ResumeFromRecall()
    {
        GameManager._instance.Player.GetComponent<PlayerControl>().StartMove();
        GameManager._instance.GetControl();
        Camera.main.GetComponent<CameraControl>().lookGameObject = GameManager._instance.Player;

        GameManager._instance.BackGroundAudio.GetComponent<Level4BackGroundAudio>().ChangeHuiYiHouing();
        Camera.main.transform.position = GameObject.Find("huiyiFlag").GetComponent<HuiyiControl>().originPos;
        Camera.main.orthographicSize = GameObject.Find("huiyiFlag").GetComponent<HuiyiControl>().originSize;
        Invoke("Whiteout", 2);
    }
}
