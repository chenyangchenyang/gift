using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuiyiControl : WrappedBehaviour {

    public GameObject player;
    public GameObject huiyiFlag;
    public GameObject[] soul = new GameObject[8];
    private int soulId = 1;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        player = GameObject.Find("huiyiFlag");
        for (int i = 0; i < 8; ++i)
        {
            soul[i] = GameObject.Find("soul" + (i + 1));
        }
	}
	
	// Update is called once per frame
	void Update () {
		if (Mathf.Abs(Camera.main.transform.position.x - huiyiFlag.transform.position.x) < 0.1)
        {
            Camera.main.GetComponent<CameraControl>().lookGameObject = null;
            Invoke("Blackot", 0);
            for (int i = 0; i < 7; ++i)
            {
                Invoke("ShowSoul", (i + 1) * 2);
            }
        }
	}

    void ShowSoul()
    {
        soul[soulId].GetComponent<Scene22AlphaControl>().ChangeVisible(false);
        soul[soulId + 1].GetComponent<Scene22AlphaControl>().ChangeVisible(true);
    }
}
