using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickControl : MonoBehaviour {

    private int state = 1;
    private float timePast = 0;
    private GameObject player;
    private GameObject huiyiFlag;
    private GameObject[] soul = new GameObject[8];

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
    }
	
	// Update is called once per frame
	void Update () {
        timePast += Time.deltaTime;
	}

    private void OnMouseUpAsButton()
    {
        if (timePast > 3)
        {
            if (state < 4)
            {
                if (state == 0)
                {
                    soul[state].transform.position = Camera.main.transform.position + new Vector3(0, 0, 10);
                    soul[state].GetComponent<Scene22AlphaControl>().ChangeVisible(true);
                }
                else
                {
                    soul[soulId].GetComponent<Scene22AlphaControl>().ChangeVisible(false);
                    soul[soulId + 1].transform.position = Camera.main.transform.position + new Vector3(0, 0, 10);
                    soul[soulId + 1].GetComponent<Scene22AlphaControl>().ChangeVisible(true);
                    Camera.main.GetComponent<CameraControl>().lookGameObject = player;
                }
                ++state;
            }
        }
    }
}
